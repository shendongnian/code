    protected void LogIn(Object sender, EventArgs E) 
    {
      // authenticate user: this sample authenticates 
      // against users in your app domain's web.config file
      if (FormsAuthentication.Authenticate(UserName.Text,
                                           Password.Text))
      {
        var persistCookie = false;
        //this is what actually sets the auth cookie.
        FormsAuthentication.RedirectFromLoginPage(UserName.Value, persistCookie);
      } 
    }
