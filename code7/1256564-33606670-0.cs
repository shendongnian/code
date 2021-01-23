    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        LoginPageViewModels ViewModel = new LoginPageViewModels();
        SqlHelper Sql = new SqlHelper();
        string ConnectionState = Sql.SqlConnectionState();
        // Check connection;
        if (ConnectionState == "Connected")
        {
            User userData= new User;
            string username = UsernameInput.Text;
            string password = PasswordInput.Password;
            userData= ViewModel.Auth(username, password);
            if (userData.Username != null)
            {
                MainPage mainPage = new MainPage();
                mainPage.UserData=userData;
                mainPage.Show();
                this.Close();
            }
            else
            {
                AuthResultMessage.Text = "User not found";
            }
        }
        else
        {
            AuthResultMessage.Text = ConnectionState;
        }
