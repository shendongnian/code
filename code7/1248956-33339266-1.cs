    var loginResult = Authenticator.Authenticate(txtUserName.Text, txtPassword.Text, out userInfo);
    if (loginResult == LoginResult.Success)
    {
      // hide the authentication form, or unlock menu, toolbars, ...
    }
    else
    {
      MessageBox.Show("Invalid user name or password");
      // the user stays on the login form and needs to press the login button again for another attempt
    }
