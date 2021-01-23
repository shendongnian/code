    private async Task SignInAsync(ApplicationUser user, bool isPersistent, string password = null)
    {
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //Get the handle and add the claim to the identity.
        var handle = GetTheHandle();
        identity.AddClaim(new Claim(CustomClaimTypes.Handle, handle);
        
        AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
    }
