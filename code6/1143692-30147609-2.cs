    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(MainWindow));
        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void ButtonTestImage_OnClick(object sender, RoutedEventArgs e)
        {
            double angle = Angle;
            
            angle += 20;
            if (angle >= 360)
            {
                angle = 0;
            }
            Angle = angle;
        }
    }
