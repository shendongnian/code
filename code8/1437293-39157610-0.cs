    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    namespace WpfApplication4
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var rectangle = new Rectangle();
                rectangle.Fill = CreateRainbowBrush(100);
                Content = rectangle;
            }
    
            public static LinearGradientBrush CreateRainbowBrush(int colors)
            {
                var brush = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(1, 0)
                };
    
                for (var i = 0; i < colors; i++)
                {
                    var d = 1.0d/colors*i;
                    var h = d*360.0d;
                    var s = 1.0d;
                    var v = 1.0d;
                    var hsvToRgb = HsvToRgb(h, s, v);
                    brush.GradientStops.Add(new GradientStop(hsvToRgb, d));
                }
                return brush;
            }
    
            public static Color HsvToRgb(double h, double s, double v)
            {
                var hi = (int) Math.Floor(h/60.0)%6;
                var f = h/60.0 - Math.Floor(h/60.0);
    
                var p = v*(1.0 - s);
                var q = v*(1.0 - f*s);
                var t = v*(1.0 - (1.0 - f)*s);
    
                switch (hi)
                {
                    case 0:
                        return ToColor(v, t, p);
                    case 1:
                        return ToColor(q, v, p);
                    case 2:
                        return ToColor(p, v, t);
                    case 3:
                        return ToColor(p, q, v);
                    case 4:
                        return ToColor(t, p, v);
                    case 5:
                        return ToColor(v, p, q);
                    default:
                        return Colors.Black;
                }
            }
    
            public static Color ToColor(double r, double g, double b)
            {
                return Color.FromRgb((byte) (r*255.0), (byte) (g*255.0), (byte) (b*255.0));
            }
        }
    }
