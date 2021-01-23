    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        int errors = 0;
        if (txtUsername.Text == "")
        {
            lblUsernameStatus.Content = "This field is required.";
            errors = errors + 1;
        }
    
        if (txtPassword.Text == "")
        {
            lblPasswordStatus.Content = "This field is required.";
            errors = errors + 1;
        }
    
        if (errors == 0)
        {
            Administrator TryLogin = new Administrator();
            if (TryLogin.VerifyUser(txtUsername.Text, txtPassword.Text))
            {
    			User.Instance.Reset(); // Make sure old data is removed
    			User.Instance.Username = txtUsername.Text;
    			User.Instance.Password = txtPassword.Text;
    			
                HomeWindow home = new HomeWindow();
                int adminID = TryLogin.userID;
                home.Show();
                this.Close();
            }
            else
            {
                lblLoginStatus.Content = TryLogin.status;
            }
        }
    }
