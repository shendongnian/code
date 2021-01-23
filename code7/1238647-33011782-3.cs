    if (HttpContext.Current.User.Identity.IsAuthenticated)
    {
        var currentUserName = HttpContext.Current.User.Identity.Name;
        
        //Load other user info here...
        var userInfo = LoadUserInfoByUsername(currentUserName);
    
        //Do something with user info....
    }
