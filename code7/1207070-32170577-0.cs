    public ActionResoult TempLogin(string username, string password)
    {
        // imaging you have own temp user manager, completely independent from identity
        if(_tempUserManager.IsValid(username,password))         
        {
            // user is valid, going to authenticate user for my App
            var ident = new ClaimsIdentity(
            new[] 
            {
                // adding following 2 claim just for supporting default antiforgery provider
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                // an optional claim you could omit this 
                new Claim(ClaimTypes.Name, username),
                // you could even add some role
                new Claim(ClaimTypes.Role, "TempUser"),
                new Claim(ClaimTypes.Role, "AnotherRole"),
                // and so on
            },
            DefaultAuthenticationTypes.ApplicationCookie);
            // Identity is sign in user based on claim don't matter 
            // how you generated it Identity 
            HttpContext.GetOwinContext().Authentication.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            // auth is succeed, 
            return RedirectToAction("MyAction"); 
         }
         ModelState.AddModelError("", "We could not authorize you :(");
         return View();
    }
