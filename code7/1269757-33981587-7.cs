    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
    }
