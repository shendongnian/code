    public void LogUserIn(string userName, string password)
    {
        //Make sure to reset, so an invalid login doesn't retain data
        LogUserOut();
    
        //Do the user validation here
    
        CurrentUser.UserName = userName;
        CurrentUser.AccessLevel = 0; //whatever was read from your user database
    }
    
    public void LogUserOut()
    {
        CurrentUser.UserName = "";
        CurrentUser.AccessLevel = int.MinValue;
    }
