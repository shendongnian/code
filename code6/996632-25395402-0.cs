    private async Task SignInAsync(ApplicationUser user, bool isPersistent)
    {
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        // Add the users primary identity details to the set of claims.
        var pocoForName = GetNameFromSomeWhere();
        identity.AddClaim(new Claim(ClaimTypes.GivenName, pocoForName));
        
        AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
    }
