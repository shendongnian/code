    public partial class MainWindow : Window
    {
        private UserSettingsVM _vm = new UserSettingsVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            _vm.WindowWidth = 1000;
        }
    }
