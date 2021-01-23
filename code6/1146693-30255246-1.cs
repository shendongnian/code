    public partial class MainWindow : Window
    {
        LogWindow _logWindow;
        public MainWindow()
        {
            InitializeComponent();
            LogText = new ObservableCollection<string>();
            _logWindow = new LogWindow();
            _logWindow.DataContext = this;
            _logWindow.Closed += _logWindow_Closed;
        }
        private void _logWindow_Closed(object sender, EventArgs e)
        {
            _logWindow = new LogWindow();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _logWindow.Show();
            LogText.Add("Button1 Clicked");
        }
        public ObservableCollection<string> LogText { get; set; }
    }
