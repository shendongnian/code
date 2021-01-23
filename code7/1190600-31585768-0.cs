    if (userManager.IsValid(login.UserName, login.Password))
    {
        var ident = new ClaimsIdentity(
          new[] { new Claim(ClaimTypes.Name,login.UserName) },
          DefaultAuthenticationTypes.ApplicationCookie);
        
        HttpContext.GetOwinContext().Authentication.SignIn(
            new AuthenticationProperties { IsPersistent = false }, ident);
    }
    
