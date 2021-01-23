      public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.Content = new TestEllipse();
            }
            
            public class TestEllipse : Canvas
            {
                private Ellipse MyEllipse;
                public TestEllipse()
                {
                    MyEllipse = new Ellipse() { StrokeThickness = 1, Fill = Brushes.Red, Height = 100, Width = 100 };
                    this.Children.Add(MyEllipse);
                    this.Loaded += TestEllipse_Loaded;
                }
    
                void TestEllipse_Loaded(object sender, RoutedEventArgs e)
                {
                    var wnd = GetWindow(this);
                    wnd.MouseMove += wnd_MouseMove;
                }
    
                void wnd_MouseMove(object sender, MouseEventArgs e)
                {
                    var coords = e.GetPosition(sender as Window);
                    Canvas.SetLeft(MyEllipse, coords.X - MyEllipse.Width / 2);
                    Canvas.SetTop(MyEllipse, coords.Y - MyEllipse.Height / 2);
                }
            }
        }
