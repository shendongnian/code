    // In App.xaml.cs:
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.ShowDialog();
    }
    // In LoginWindow.xaml.cs
    public LoginWindow()
    {
        InitializeComponent();
        this.Closed += LoginWindow_Closed;
    }
    protected void LoginWindow_Closed(object sender, EventArgs e)
    {
        if (this.UserIsAuthenticated)
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
