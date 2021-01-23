    public override async Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser) { var userIdentity = await CreateUserIdentityAsync(user); // your code here userIdentity.AddClaim(new Claim(ClaimTypes.Gender, "male")); // AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie); if (rememberBrowser) { var rememberBrowserIdentpublic override async Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser)
    {
        var userIdentity = await CreateUserIdentityAsync(user);
    
        // your code here
        userIdentity.AddClaim(new Claim(ClaimTypes.Gender, "male"));
        //
    
        uthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
        if (rememberBrowser)
        {
            var rememberBrowserIdentity = AuthenticationManager.CreateTwoFactorRememberBrowserIdentity(ConvertIdToString(user.Id));
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, userIdentity, rememberBrowserIdentity);
        }
    	else
    	{
    		AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, userIdentity);
    	}
    }
