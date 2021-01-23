    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static Line myLine = new Line
        {
            Stroke = Brushes.GreenYellow,
            StrokeThickness = 2,
            Visibility = Visibility.Visible
        };
        bool _firstPoint;
        private void image_zoom0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (_firstPoint)
                {
                    grid2.Children.Remove(myLine);                                      // remove line first
                    System.Windows.Point position = Mouse.GetPosition(image_zoom0);
                    myLine.X1 = position.X;
                    myLine.Y1 = position.Y;
                    _firstPoint = false;
                }
                else
                {
                    System.Windows.Point position = Mouse.GetPosition(image_zoom0);
                    myLine.X2 = position.X;
                    myLine.Y2 = position.Y;
                    _firstPoint = true;
                    grid2.Children.Add(myLine);                                         // draw line
                    //Canvas.SetZIndex(myLine, 99);
                }
            }
        }
    }
