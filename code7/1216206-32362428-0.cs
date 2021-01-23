    // imaging this action is called by proxy
    public ActionResoult Login()
    {
        // this custom method extract username from header and check IP and more
        var username=_myUserManager.GetUserName();
    
        if(username!=null)         
        {
            // optionally you have own user manager which returns roles from username
            // no matter how you store users and roles
            string[] roles=_myUserManager.GetUserRoles(username);
    
            // user is valid, going to authenticate user for my App
            var ident = new ClaimsIdentity(
                new[] 
                {  
                    // adding following 2 claim just for supporting default antiforgery provider
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
    
                    // an optional claim you could omit this 
                    new Claim(ClaimTypes.Name, username),
    
                    // populate assigned user's role form your DB 
                    // and add each one as a claim  
                    new Claim(ClaimTypes.Role, roles[0]),
                    new Claim(ClaimTypes.Role, roles[1]),
                    // and so on
                },
                DefaultAuthenticationTypes.ApplicationCookie);
    
            // Identity is sign in user based on claim don't matter 
            // how you generated it             
            HttpContext.GetOwinContext().Authentication.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
    
            // auth is succeed, without needing any password just claim based 
            return RedirectToAction("MyAction"); 
        }
        // invalid user        
        ModelState.AddModelError("", "We could not authorize you :(");
        return View();
    }
