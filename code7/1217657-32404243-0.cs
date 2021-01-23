    public ActionResoult Login(string token)
    {
        if(_tokenManager.IsValid(token))         
        {
            // optionally you have own user manager which returns roles and user name from token
            // no matter how you store users and roles
            var user=_myUserManager.GetUserRoles(token);
    
            // user is valid, going to authenticate user for my App
            var ident = new ClaimsIdentity(
                new[] 
                {  
                    // adding following 2 claim just for supporting default antiforgery provider
                    new Claim(ClaimTypes.NameIdentifier, token),
                    new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
    
                    // an optional claim you could omit this 
                    new Claim(ClaimTypes.Name, user.Username),
    
                    // populate assigned user's role form your DB 
                    // and add each one as a claim  
                    new Claim(ClaimTypes.Role, user.Roles[0]),
                    new Claim(ClaimTypes.Role, user.Roles[1]),
                    // and so on
                },
                DefaultAuthenticationTypes.ApplicationCookie);
    
            // Identity is sign in user based on claim don't matter 
            // how you generated it             
            HttpContext.GetOwinContext().Authentication.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
    
            // auth is succeed, just from a token
            return RedirectToAction("MyAction"); 
        }
        // invalid user        
        ModelState.AddModelError("", "We could not authorize you :(");
        return View();
    }
