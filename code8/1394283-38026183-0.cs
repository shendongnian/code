    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    namespace WpfAnimation
    {
        /// <summary>
        /// Interaction logic for BeamControl.xaml
        /// </summary>
        public partial class BeamControl : UserControl
        {
    
            Path _beamPath;
    
            public Panel Sensor
            {
                get { return (Panel)GetValue(SensorProperty); }
                set { SetValue(SensorProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Sensor.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SensorProperty =
                DependencyProperty.Register("Sensor", typeof(Panel), typeof(BeamControl), new PropertyMetadata(null));
            
            private  double left;
            private double top;
    
            public BeamControl()
            {
                InitializeComponent();
    
                this.Loaded += BeamControl_Loaded;             
            }
    
            void BeamControl_Loaded(object sender, RoutedEventArgs e)
            {
                _beamPath = this.Content as Path;
    
                left = Canvas.GetLeft(this);
                top = Canvas.GetTop(this);
    
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        _doDetection();
                    }
    
                });
            }
    
            void _doDetection()
            {
                // 200 is the height of the beam, you can change it
                for (double i = top; i < 200; i = i + 1)
                {
                    System.Diagnostics.Debug.WriteLine(i.ToString());
                    Point pt = new Point(left + 20.0, i);
    
                    this.Dispatcher.Invoke(() =>
                    {
                        VisualTreeHelper.HitTest(Sensor,
                            new HitTestFilterCallback((o) =>
                            {
                                if (o is Ellipse)
                                {
                                    _beamPath.Fill = Brushes.DarkKhaki;
                                    System.Diagnostics.Debug.WriteLine("Detected ! " + o.GetType().ToString());
                                    System.Diagnostics.Debug.WriteLine(pt.ToString());
                                    return HitTestFilterBehavior.Stop;
                                }
                                else
                                    System.Diagnostics.Debug.WriteLine(o.GetType().ToString());
    
                                return HitTestFilterBehavior.Continue;
                            }),
                            new HitTestResultCallback((result) => { return HitTestResultBehavior.Continue; }),
                            new PointHitTestParameters(pt));
                    });
                }
            }
        }
    }
