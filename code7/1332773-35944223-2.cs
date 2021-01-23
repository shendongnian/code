    public async Task RevertImpersonationAsync()
    {
        var context = HttpContext.Current;
    
        if (!HttpContext.Current.User.IsImpersonating())
        {
            throw new Exception("Unable to remove impersonation because there is no impersonation");
        }
    
    
        var originalUsername = HttpContext.Current.User.GetOriginalUsername();
    
        var originalUser = await userManager.FindByNameAsync(originalUsername);
    
        var impersonatedIdentity = await userManager.CreateIdentityAsync(originalUser, DefaultAuthenticationTypes.ApplicationCookie);
        var authenticationManager = context.GetOwinContext().Authentication;
    
        authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, impersonatedIdentity);
    }
