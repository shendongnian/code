    public App()
    {
      var isLoggedIn = App.Current.Properties.ContainsKey("IsLoggedIn")? (bool)Properties["IsLoggedIn"] : false;
        // The root page of your application
        if (isLoggedIn)
        {
            MainPage = new MasterPage();
        }
        else
        {
           MainPage = new NavigationPage(new carousel());
        }
    }
