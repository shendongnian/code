     public void LoginButton_Clicked(object sender, EventArgs e)
    {
        LdapAuthentication auth = new LdapAuthentication("YOURPATH");
        if (auth.IsAuthenticated("YOURDOMAIN", txtId.Text, txtPassword.Text))
        {
            //Login Passed
        }
    }
