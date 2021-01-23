    public partial class MainWindow : Window
    {
        private const string CarTransform = "CarTransform";
        private Image _car;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindow_Loaded;
            // create and add Car image to LayoutRoot grid
            _car = new Image();
            _car.Source = new BitmapImage(new Uri("/car-icon-hi.png", UriKind.Relative));
            _car.Width = 64;
            _car.Height = 64;
            _car.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            _car.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            _car.Margin = new Thickness(5);
            _car.RenderTransform = new TranslateTransform();
            LayoutRoot.Children.Add(_car);
        }
        private DoubleAnimation CreateAnimationFor(double from, double to, TimeSpan? beginTime, string targetName, DependencyProperty propertyPath)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = from;
            da.To = to;
            da.Duration = new Duration(TimeSpan.FromMilliseconds(1000));
            if (beginTime != null)
                da.BeginTime = beginTime;
            Storyboard.SetTargetName(da, targetName);
            Storyboard.SetTargetProperty(da, new PropertyPath(propertyPath));
            return da;
        }
        private void StartAnimationClick(object sender, RoutedEventArgs e)
        {
            TranslateTransform _trans = _car.RenderTransform as TranslateTransform;
            this.RegisterName(CarTransform, _trans); // register name for TranslateTransform instance, this action is needed for working a Storyboard with multiple animations
            Storyboard sb = new Storyboard();
            // from A to B
            sb.Children.Add(CreateAnimationFor(0, 100, null, CarTransform, TranslateTransform.XProperty));
            sb.Children.Add(CreateAnimationFor(0, 0, null, CarTransform, TranslateTransform.YProperty));
            // from B to C
            sb.Children.Add(CreateAnimationFor(100, 100, TimeSpan.FromSeconds(1), CarTransform, TranslateTransform.XProperty));
            sb.Children.Add(CreateAnimationFor(0, 100, TimeSpan.FromSeconds(1), CarTransform, TranslateTransform.YProperty));
            // from C to D
            sb.Children.Add(CreateAnimationFor(100, 300, TimeSpan.FromSeconds(2), CarTransform, TranslateTransform.XProperty));
            sb.Children.Add(CreateAnimationFor(100, 250, TimeSpan.FromSeconds(2), CarTransform, TranslateTransform.YProperty));
            sb.Begin(this);
        }
    }
