    public partial class MainWindow : Window
    {
        private ViewModel localDataContext;
        public MainWindow()
        {
            InitializeComponent();
            var myViewModel = new ViewModel();
            DataContext = myViewModel;
            localDataContext = (ViewModel) DataContext;
        }
        private void sendIpAddres(object sender, EventArgs e)
        {
            MyTextBox.Text = localDataContext.ipAddress;
        }
    }
