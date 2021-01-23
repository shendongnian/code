    public partial class MainWindow : Window
    {
        static Window1 w1Instance = new Window1(OpenWindow2);
        static Window2 w2Instance = new Window2(OpenWindow1);
        public MainWindow()
        {
            InitializeComponent();
        }
        static bool OpenWindow1()
        {
            w1Instance.Visibility = Visibility.Visible;
            w2Instance.Visibility = Visibility.Collapsed;
            return true;
        }
        static bool OpenWindow2()
        {
            w1Instance.Visibility = Visibility.Collapsed;
            w2Instance.Visibility = Visibility.Visible;
            return true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenWindow1();
            Visibility = Visibility.Collapsed;
        }
    }
    public partial class Window1 : Window
    {
        Func<bool> showWindow;
        public Window1(Func<bool> showWindowP)
        {
            InitializeComponent();
            showWindow = showWindowP;
        }
        private void cmdHideThis_Click(object sender, RoutedEventArgs e)
        {
            showWindow();
        }
    }
    public partial class Window2 : Window
    {
        Func<bool> closeWindow;
        public Window2(Func<bool> closeWindow2)
        {
            InitializeComponent();
            closeWindow = closeWindow2;
        }
        private void cmdHideThis_Click(object sender, RoutedEventArgs e)
        {
            closeWindow();
        }
    }
