    private async Task SignInAsync(ApplicationUser user, bool isPersistent) 
    { 
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);  
        var identity = await user.GenerateUserIdentityAsync(UserManager);
        //add your claim here
        AuthenticationManager.SignIn(new AuthenticationProperties() 
            { 
                IsPersistent = isPersistent 
            }, identity);
    }
