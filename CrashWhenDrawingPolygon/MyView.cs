﻿using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using SkiaSharp;
using SkiaSharp.Views.iOS;
using UIKit;

namespace CrashWhenDrawingPolygon
{
    public class MyView : UIView
    {
        private SKGLView _canvas;
        private SKPoint _center;
        private SKPath _path;
        private SKPath _originalPath;
        private float _scale = 0.0005f;

        public MyView(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        [Preserve]
        public MyView(IntPtr handle) : base(handle) // used when initialized from storyboard
        {
            Initialize();
        }

        private void Initialize()
        {
            _canvas = new SKGLView(Frame)
            {
                BackgroundColor = UIColor.White
            };

            ClipsToBounds = true;
            AddSubview(_canvas);
            _canvas.PaintSurface += CanvasOnPaintSurface;

            _originalPath = ToPath("601460.84271555 6161723.18906461, 601460.99114075 6161722.05929457, 601462.68978467 6161718.29006179, 601468.58556334 6161712.2112991, 601476.17998594 6161706.73241431, 601484.83812245 6161702.30331584, 601506.96996854 6161687.97623208, 601532.15277702 6161670.56977511, 601555.30710781 6161653.55323878, 601578.85723911 6161632.37754903, 601627.0129698 6161570.66011144, 601643.94168814 6161548.97452548, 601649.23552018 6161535.4772728, 601651.87419036 6161531.43809496, 601683.36506972 6161483.57783678, 601704.45793943 6161452.24421465, 601726.95260267 6161440.3366384, 601735.31388879 6161435.74757249, 601760.43897636 6161415.03178913, 601783.67576558 6161396.05565167, 601801.288889 6161374.61001687, 601802.79787851 6161333.37840944, 601801.26415147 6161320.62100617, 601796.21769476 6161291.11701163, 601793.36463263 6161266.99192222, 601791.49282598 6161254.38448843, 601790.33016193 6161242.80684502, 601789.27469386 6161228.53974905, 601789.52206919 6161216.13227455, 601789.55505257 6161211.12329412, 601788.53256787 6161206.80417326, 601786.31443576 6161196.77621442, 601782.45538063 6161180.33956006, 601779.20651798 6161168.95187799, 601779.71776032 6161158.03410027, 601780.58357397 6161147.12632051, 601786.41338589 6161132.25934664, 601791.55054689 6161123.87105406, 601799.3346239 6161115.48276147, 601808.61944458 6161107.61436306, 601819.61940087 6161099.4460257, 601827.37874035 6161093.92714905, 601833.71979462 6161088.4082724, 601842.17178502 6161079.84001645, 601852.91612014 6161066.60271086, 601863.6687011 6161053.39539917, 601872.29385423 6161044.83714118, 601884.6296373 6161035.92895442, 601895.71205203 6161030.30010015, 601907.14079223 6161023.97138835, 601925.47954994 6161015.18317716, 601938.43377133 6161009.16440227, 601947.32279148 6161002.965664, 601954.232809 6160992.17785983, 601960.07086677 6160982.17989488, 601969.04234536 6160965.51328732, 601973.07456322 6160954.84545873, 601972.29120801 6160942.15804122, 601969.21550809 6160928.24087402, 601966.73350896 6160919.44266487, 601962.14057368 6160914.53366408, 601957.57237594 6160910.55447403, 601955.8325028 6160907.27514153, 601955.71706098 6160897.76707687, 601957.58062179 6160889.10883923, 601958.04238907 6160881.86031464, 601957.24200669 6160873.93192844, 601957.85273465 6160866.00354224, 601957.93519309 6160854.23593751, 601960.82948444 6160846.48751468, 601962.31373641 6160840.68869501, 601968.81146172 6160827.67134465, 601976.03482132 6160814.58400854, 601982.54903832 6160802.11654626, 601984.47856588 6160796.50768792, 601985.62473824 6160791.22876243, 601988.17270413 6160788.77926102, 601990.55575313 6160786.53971688, 601996.3773192 6160782.98044135, 602004.3263131 6160779.25120043, 602015.30153186 6160775.25201445, 602023.6298346 6160771.43279185, 602032.01585825 6160764.67416754, 602040.41012774 6160754.74618836, 602046.9738198 6160745.14814201, 602053.90032901 6160736.25995118, 602058.97152325 6160731.96082625, 602065.09818556 6160729.06141642, 602071.66187762 6160728.79147136, 602075.57865366 6160729.94123733, 602082.25778754 6160735.00020759, 602087.19704828 6160738.8194302, 602088.41743323 6160741.13895807, 602084.17082342 6160743.81841267, 602077.59063967 6160748.09754167, 602071.71135269 6160754.49623923, 602067.25035093 6160764.31424081, 602062.81408669 6160778.11143243, 602054.79088019 6160795.87781613, 602047.80665008 6160808.05533743, 602042.58703064 6160821.29264302, 602037.28495275 6160836.2995884, 602036.69949781 6160842.93823712, 602035.40490025 6160852.56627736, 602033.26922658 6160862.38427893, 602030.06983899 6160876.43141968, 602024.59459838 6160893.54793566, 602020.52939714 6160907.14516799, 602017.70107255 6160919.0627422, 602015.92821603 6160932.04010069, 602011.30229738 6160944.26761182, 602007.03095003 6160957.7348706, 602004.2521005 6160962.53389377, 602001.74536384 6160970.69223316, 602000.68989577 6160981.46004141, 601999.3375773 6160990.25825056, 601998.53773041 6160999.38639255, 602000.91253356 6161008.34456914, 602000.57445395 6161014.71327281, 601999.18090626 6161021.07197851, 601993.88707422 6161037.94854334, 601991.2401582 6161047.61657544, 601989.64871026 6161056.93467876, 601988.23042504 6161068.59230589, 601987.85936204 6161081.65964607, 601988.18919582 6161104.60497561, 601989.28589311 6161115.32279403, 601991.08348716 6161120.45175005, 601993.58197798 6161125.92063687, 601998.23263417 6161131.93941177, 601999.96426147 6161135.0387809, 602000.5662081 6161138.3481073, 602002.58643996 6161139.18793635, 602004.4005257 6161146.01654641, 602007.08867094 6161157.254259, 602005.79407339 6161158.6239802, 602003.26259919 6161156.114491, 601998.36456768 6161155.57460089, 601995.222901 6161157.86413486, 601991.02576625 6161162.29323333, 601988.16445828 6161165.29262282, 601985.65772162 6161169.35179658, 601983.53853963 6161177.7600851, 601981.77392895 6161185.29855067, 601979.0280628 6161188.61787503, 601977.86539876 6161191.05737847, 601977.31292719 6161197.6960272, 601974.78145299 6161203.56483262, 601967.26124299 6161225.89028834, 601962.10759031 6161243.58668629, 601960.05437508 6161255.54425236, 601959.06487376 6161267.86174517, 601959.98016248 6161279.21943334, 601962.94042058 6161283.63853385, 601967.13755533 6161287.34777884, 601972.86841711 6161289.40735962, 601976.44711354 6161289.27738608, 601982.31815468 6161290.74708692, 601990.21767351 6161292.91664532, 601997.23488701 6161294.02641942, 602011.269314 6161296.96582112, 602016.1096246 6161297.97561558, 602023.42368849 6161299.87522892, 602034.86067453 6161305.43409743, 602046.09151446 6161311.22291913, 602056.06074022 6161314.74220279, 602067.26684261 6161319.31127277, 602079.1408584 6161322.60060323, 602083.34623899 6161323.5504099, 602091.43541225 6161324.51021454, 602102.66625218 6161328.52939644, 602114.30938432 6161331.29883273, 602128.67364509 6161332.55857632, 602137.90074485 6161333.16845218, 602149.04912634 6161335.93788847, 602160.26347459 6161337.44758117, 602170.94184295 6161337.8974896, 602178.58574061 6161337.62754454, 602181.34809845 6161336.43778671, 602183.40131368 6161337.00767072, 602192.55420085 6161342.6865148, 602202.06165932 6161348.71528766, 602207.32250798 6161352.66448382, 602212.58335664 6161358.71325261, 602216.04661125 6161362.18254644, 602221.95063576 6161371.48065384, 602225.43038206 6161378.68918656, 602231.38388164 6161391.0266753, 602240.24816426 6161405.18379366, 602251.41303743 6161419.88080213, 602260.2855659 6161431.2384903, 602266.55240756 6161433.88795101, 602274.58385991 6161436.53741172, 602292.41137527 6161441.1364756, 602297.12799821 6161456.1934108, 602298.40610408 6161463.96182956, 602296.16323443 6161467.49111119, 602293.3101723 6161473.97979044, 602288.87390807 6161483.10793243, 602284.429398 6161493.11589534, 602280.53735949 6161497.65497142, 602274.69930173 6161504.84350822, 602267.26155017 6161512.16201856, 602257.71286247 6161518.58071205, 602244.63495342 6161526.39912063, 602236.50455095 6161531.0581723, 602233.66798051 6161533.06776325, 602228.67924471 6161533.12775104, 602211.51139689 6161533.00777546, 602207.52865409 6161533.83760655, 602205.5578973 6161534.76741729, 602202.2430679 6161532.93778971, 602196.28956831 6161529.6884511, 602185.34733293 6161525.82923663, 602175.81513693 6161522.66987971, 602170.91710542 6161522.02001199, 602163.55356646 6161522.42992855, 602148.12559178 6161523.59969045, 602124.31159345 6161525.59928344, 602106.03055665 6161525.0393974, 602096.17677272 6161525.98920407, 602089.33272195 6161527.28893951, 602086.10035099 6161526.21915727, 602081.11161519 6161523.90962736, 602078.57189514 6161522.19997536, 602075.32303249 6161515.21139786, 602070.5404428 6161503.98368323, 602067.52246379 6161501.94409838, 602061.6431768 6161490.54641835, 602054.35385045 6161481.62823362, 602049.26616452 6161474.10976398, 602043.82390728 6161468.0010074, 602037.65601575 6161462.44213889, 602022.31049951 6161454.06384427, 602020.90870598 6161452.96406813, 602019.85323791 6161449.74472341, 602015.63136563 6161448.25502664, 601989.24466389 6161441.94631076, 601968.29197353 6161438.44702303, 601964.62257282 6161437.75716345, 601962.02513186 6161437.91713089, 601945.13764275 6161442.3062375, 601927.07099789 6161446.47538888, 601907.94063913 6161452.73411493, 601888.81028036 6161457.62311979, 601877.05170639 6161463.29196591, 601862.47305368 6161471.0803806, 601851.47309739 6161477.53906596, 601850.0053371 6161479.7786101, 601849.09004839 6161483.07793853, 601846.41014899 6161485.31748268, 601838.58484275 6161492.96592586, 601834.93193373 6161494.16568166, 601834.08261177 6161495.42542524, 601832.72204746 6161500.66435887, 601831.00691184 6161507.31300556, 601830.40496521 6161513.90166446, 601828.13735803 6161523.20976982, 601822.60439651 6161538.24670909, 601822.21684182 6161541.60602531, 601820.60065634 6161543.89555928, 601820.18011828 6161546.7149854, 601821.80454961 6161549.18448274, 601822.77755924 6161550.77415917, 601823.92373159 6161553.56359138, 601823.93197744 6161560.6021587, 601827.84875348 6161568.87047571, 601827.49418217 6161575.75907356, 601826.05115942 6161580.37813336, 601823.37950587 6161583.94740685, 601820.62539387 6161588.90639746, 601815.56244548 6161594.43527207, 601800.7116799 6161617.70053649, 601784.22823715 6161642.30552822, 601778.61281719 6161650.08394495, 601777.75524938 6161654.50304545, 601775.68554246 6161661.23167586, 601771.15857394 6161674.99887358, 601771.39770343 6161680.1278296, 601771.80999564 6161690.01581693, 601771.23278654 6161695.68466305, 601768.89096676 6161703.85300041, 601767.43145232 6161718.54001091, 601767.15109362 6161723.80893844, 601767.92620298 6161729.78772147, 601769.65783028 6161735.55654724, 601771.1503281 6161741.09541982, 601770.29276029 6161749.5437002, 601768.71780403 6161772.47903178, 601770.15258094 6161778.53779853, 601770.53188978 6161792.88487823, 601766.94494751 6161810.90121106, 601760.85951442 6161831.01711652, 601756.47272525 6161837.79573675, 601749.43902007 6161847.90367931, 601742.27338137 6161855.44214488, 601735.28090541 6161861.75086076, 601727.40612411 6161868.84941587, 601722.59055104 6161873.45847771, 601719.88591411 6161878.06753954, 601713.05010919 6161894.54418577, 601700.64011352 6161931.93657466, 601692.20461481 6161950.79273654, 601686.70463666 6161970.78866643, 601686.31708198 6161977.98720119, 601687.85905486 6161984.1159537, 601691.28932609 6161990.0747408, 601694.95048096 6161998.12310258, 601697.73757633 6162004.24185713, 601697.47370931 6162012.54016803, 601695.23083967 6162024.97763642, 601691.13265505 6162035.1355688, 601684.52773377 6162046.84318575, 601678.14545028 6162062.71995408, 601673.70094021 6162070.8982894, 601671.73018342 6162079.60651687, 601671.00454912 6162088.65467514, 601670.98805743 6162099.82240198, 601672.3403759 6162109.2004931, 601674.04726567 6162119.27844176, 601678.07123768 6162138.81446526, 601679.67093148 6162145.92301834, 601680.92429981 6162155.49107079, 601679.49776875 6162181.80571452, 601676.00977661 6162195.4129448, 601671.63947913 6162205.67085684, 601660.07055959 6162216.33868543, 601655.09831548 6162221.77757836, 601650.82696813 6162228.0962922, 601648.52637757 6162235.79472521, 601648.69129446 6162242.07344719, 601650.4311676 6162253.8510499, 601654.29022274 6162268.61804412, 601655.90640822 6162273.62702455, 601657.51434785 6162286.03449905, 601658.8996497 6162290.44360159, 601660.45811427 6162295.38259627, 601665.96633826 6162298.55195116, 601670.93858237 6162302.591129, 601672.16721317 6162306.2403862, 601673.21443539 6162314.29874594, 601675.66345115 6162320.89740281, 601676.40557714 6162323.17693881, 601678.20317119 6162325.46647279, 601681.45203385 6162325.79640563, 601682.54873114 6162322.60705481, 601681.88906359 6162316.24834911, 601680.56148266 6162310.21957625, 601681.91380113 6162304.93065279, 601684.32983351 6162301.05144239, 601686.68814497 6162295.75252097, 601687.94151331 6162287.92411442, 601689.27734008 6162278.06612099, 601689.90402425 6162268.38809092, 601689.13716073 6162259.77984311, 601687.6611546 6162253.28116589, 601681.68291749 6162240.55375652, 601679.72040654 6162232.16546393, 601675.33361738 6162229.18607038, 601673.4205815 6162226.92653031, 601674.24516593 6162225.28686405, 601677.15594897 6162222.93734229, 601682.36732256 6162220.04793042, 601688.55170579 6162214.98896016, 601696.12139085 6162212.76941195, 601705.10111529 6162205.84082224, 601709.63632965 6162205.23094638, 601709.24877497 6162215.1789215, 601706.1648292 6162241.42357947, 601707.50065598 6162268.54805836, 601705.22480295 6162291.753335, 601705.34024477 6162317.70805199, 601702.64385369 6162344.01269775, 601700.40922988 6162364.39854827, 601698.27355621 6162373.93660683, 601696.31929111 6162379.95538173, 601693.46622899 6162385.27429908, 601685.34407235 6162395.99211749, 601679.81935668 6162406.84990742, 601676.76839429 6162412.94866604, 601669.5862639 6162443.66241434, 601666.16423852 6162471.21680573, 601665.21596643 6162479.15518989, 601666.03230501 6162487.45350079, 601669.47082208 6162503.91015109, 601673.25566462 6162522.48636995, 601673.53602332 6162538.80304874, 601671.82088771 6162548.35110526, 601667.16198568 6162557.4392554, 601661.79394104 6162564.40783696, 601651.18153944 6162571.87631677, 601647.81723496 6162573.96589145, 601646.56386663 6162576.76532163, 601643.3562332 6162579.53475792, 601637.65010895 6162583.66391744, 601634.78880097 6162586.60331913, 601629.27233114 6162586.32337612, 601608.10524883 6162581.29439975, 601592.24024441 6162586.85326826, 601584.90968883 6162583.27399681, 601563.5848645 6162572.04337913, 601554.14444376 6162554.31989033, 601552.03350762 6162549.29091397, 601552.70142101 6162535.30376101, 601548.47130288 6162490.86280684, 601554.68042364 6162465.70792704, 601564.99597485 6162441.37288037, 601573.34076928 6162421.55691385, 601575.97943946 6162409.39938848, 601580.39990341 6162398.13003071, 601585.11150581 6162377.94786601, 601573.83551994 6162357.30999113, 601566.46518871 6162319.98979449, 601576.51541933 6162300.41157264, 601586.39712239 6162273.24676429, 601587.44940887 6162260.7796396, 601594.19099652 6162232.19057404, 601580.21780342 6162208.89020155, 601586.39712239 6162196.34124998, 601589.05330448 6162188.54623799, 601593.97187171 6162164.45924534, 601599.78519194 6162161.27989249, 601593.44413767 6162154.93118475, 601588.15030564 6162104.68141295, 601592.38042376 6162104.1515208, 601590.26948762 6162086.69507401, 601591.32495569 6162073.46776639, 601605.29548864 6162054.47366533, 601594.51100691 6162046.41077518, 601592.9081578 6162033.78584353, 601614.60297414 6162008.93090268, 601613.01152619 6162003.63198126, 601587.87285152 6162032.28105808, 601578.6168592 6162078.92354417, 601578.98879308 6162042.70661039, 601576.51541933 6162033.26594936, 601572.27705537 6162025.32756519, 601573.34076928 6162013.689934, 601565.25859391 6161986.64241244, 601558.45779225 6161953.03883042, 601552.70966685 6161926.92759422, 601547.28514364 6161911.10468535, 601543.46103176 6161896.05989213, 601536.12509802 6161871.66998182, 601530.54483738 6161858.82145703, 601520.05020805 6161843.89099071, 601516.51865624 6161839.18545388, 601495.58023148 6161823.48597077, 601493.61661697 6161823.63172791, 601482.41205051 6161795.23133426, 601477.56528778 6161780.94730809, 601470.51114867 6161762.34316415, 601463.45700956 6161738.800134, 601460.84271555 6161723.18906461");
            _path = ToPath(_originalPath.Points.Select(p => new SKPoint(p.X * _scale, p.Y * _scale)));
            _center = new SKPoint((float)Frame.Width * 0.5f, (float)Frame.Height * 0.5f);
        }

        private SKPath ToPath(string polygonString)
        {
            return ToPath(polygonString.Split(',').Select(ToSKPoint));
        }

        private static SKPath ToPath(IEnumerable<SKPoint> points)
        {
            var path = new SKPath();

            foreach (var point in points)
            {
                if (path.Points.Length == 0)
                    path.MoveTo(point);
                else
                    path.LineTo(point);
            }
            path.Close();

            return path;
        }

        private SKPoint ToSKPoint(string pair)
        {
            var splitPair = pair.Trim().Split(' ');
            return new SKPoint(float.Parse(splitPair[0]), float.Parse(splitPair[1]));
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);

            if (evt.AllTouches.Count == 2)
            {
                var previousLocations = evt.AllTouches.Select(t => ((UITouch)t).PreviousLocationInView(this))
                    .Select(p => new SKPoint((float)p.X, (float)p.Y)).ToList();
                var previousDistance = Distance(previousLocations[0], previousLocations[1]);

                var locations = evt.AllTouches.Select(t => ((UITouch) t).LocationInView(this))
                    .Select(p => new SKPoint((float)p.X, (float)p.Y)).ToList();
                var distance = Distance(locations[0], locations[1]);

                _scale = _scale * (distance / previousDistance);
                _path = ToPath(_originalPath.Points.Select(p => new SKPoint(p.X * _scale, p.Y * _scale)));
            }

            SetNeedsDisplay();
            _canvas?.SetNeedsDisplay();

        }

        private float Distance(SKPoint skPoint1, SKPoint skPoint2)
        {
            return (float)Math.Sqrt(Math.Pow(skPoint1.X - skPoint2.Y, 2) + Math.Pow(skPoint1.Y - skPoint2.Y, 2));
        }

        private void CanvasOnPaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Scale((float)_canvas.ContentScaleFactor);
            canvas.Clear(SKColors.White);
            canvas.Translate(_center.X - _path.Bounds.MidX, _center.Y - _path.Bounds.MidY);
            var paint = new SKPaint { Color = SKColors.Red, StrokeWidth = 10, Style = SKPaintStyle.StrokeAndFill };
            e.Surface.Canvas.DrawPath(_path, paint);
        }
    }
}