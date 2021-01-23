    public partial class Login : Page
    {
        MainWindow _window;
        public Login(MainWindow window)
        {
            InitializeComponent();
            _window = window;
        }
    
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            _window.pnlLeftMenu.Visibility = System.Windows.Visibility.Visible;
            Home hPage = new Home();
            this.NavigationService.Navigate(hPage);
        }
    }
