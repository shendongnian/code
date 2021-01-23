    void Session_OnStart()
    {
        UserProvider userProvider = DependencyResolver.Current.GetService<UserProvider>();
        userProvider.LoadCurrentUser(); 
    }
