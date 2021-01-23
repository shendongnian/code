    // MobileServiceAuthenticationToken <- your token
    var facebook = new FacebookGraphAPI(MobileServiceAuthenticationToken);
    
    // Get user profile data 
    var user = facebook.GetObject("me", null);
    Console.WriteLine(user["name"]);
