    public static MainWindow W;
    private void EnterPressed(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Return)
        {
            if (UserAuthenticationService.AuthenticateUser(passwordBox.Password))
            {
                var lGs = new LoginService();
                var sqlServerCheck = new MySQLServerCheck();
                if (sqlServerCheck.ServerIsOnline())
                {
                    W.ShowSDCImage();                    
                    NavigationService.Navigate(new Uri("View/MainPages/DashboardPage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Sorry, the server is offline. Please notify IT.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
            e.Handled = true;
        }
    
        if (e.Key == Key.Escape)
        {
            Application.Current.Shutdown();
        }
    }
