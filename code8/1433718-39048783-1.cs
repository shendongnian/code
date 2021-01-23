    public partial class MainWindow : Window
    {
        static Window1 w1Instance = new Window1(OpenWindow2);
        static Window2 w2Instance = new Window2(OpenWindow1);
        public MainWindow()
        {
            InitializeComponent();
        }
        static void OpenWindow1()
        {
            w1Instance.Visibility = Visibility.Visible;
            w2Instance.Visibility = Visibility.Collapsed;
        }
        static void OpenWindow2()
        {
            w1Instance.Visibility = Visibility.Collapsed;
            w2Instance.Visibility = Visibility.Visible;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenWindow1();
            Visibility = Visibility.Collapsed;
        }
    }
    public partial class Window1 : Window
    {
        Action OpenWindow2;
        public Window1(Action OpenWindow2ToSet)
        {
            InitializeComponent();
            OpenWindow2 = OpenWindow2ToSet;
        }
        private void cmdHideThis_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow2();
        }
    }
    public partial class Window2 : Window
    {
        Action OpenWindow1;
        public Window2(Action OpenWindow1ToSet)
        {
            InitializeComponent();
            OpenWindow1 = OpenWindow1ToSet;
        }
        private void cmdHideThis_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow1();
        }
    }
