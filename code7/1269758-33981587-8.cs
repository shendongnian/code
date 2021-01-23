        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty XProperty = DependencyProperty.Register(
            "X", typeof (double), typeof (MainWindow), new PropertyMetadata(default(double)));
        public double X
        {
            get { return (double) GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }
        public static readonly DependencyProperty YProperty = DependencyProperty.Register(
            "Y", typeof (double), typeof (MainWindow), new PropertyMetadata(default(double)));
        
        private static double _position;
        public double Y
        {
            get { return (double) GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            X = ++_position;
            Y = _position;
        }
        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as Grid;
            if(grid == null) return;
            var transform = grid.RenderTransform as TranslateTransform;
            if (transform == null)
            {
                transform = InitTransformBinding();
                grid.RenderTransform = transform;
            }
            else
            {
                InitTransformBinding(transform);
            }
        }
        private TranslateTransform InitTransformBinding(TranslateTransform t = null)
        {
            var transform = t ?? new TranslateTransform();
            var xBinding = new Binding();
            xBinding.Source = this;
            xBinding.Path = new PropertyPath("X");
            xBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            xBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(transform, TranslateTransform.XProperty, xBinding);
            var yBinding = new Binding();
            yBinding.Source = this;
            yBinding.Path = new PropertyPath("Y");
            yBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            yBinding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(transform, TranslateTransform.YProperty, yBinding);
            return transform;
        }
    }
