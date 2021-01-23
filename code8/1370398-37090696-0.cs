    public override async Task SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser)
    {
        var userIdentity = await CreateUserIdentityAsync(user).WithCurrentCulture();
        // Clear any partial cookies from external or two factor partial sign ins
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
        if (rememberBrowser)
        {
            var rememberBrowserIdentity = AuthenticationManager.CreateTwoFactorRememberBrowserIdentity(ConvertIdToString(user.Id));
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, userIdentity, rememberBrowserIdentity);
        }
        else
        {
            //AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, userIdentity);
            if (isPersistent)
            {
                AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, userIdentity);
            }
            else
            {
                AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) }, userIdentity);
            }        
        }
    }
