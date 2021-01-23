    //Get the authentication manager
    var authenticationManager = HttpContext.GetOwinContext().Authentication;
    
    //Log the user out
    authenticationManager.SignOut();
    
    //Log the user back in
    var identity = manager.CreateIdentity(user,DefaultAuthenticationTypes.ApplicationCookie);
    authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { IsPersistent = true}, identity);
