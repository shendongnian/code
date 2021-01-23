    private async Task SignInAsync(ApplicationUser user, bool isPersistent)
    {
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //Fetch data from the UserMaster table 
        var userdata = GetdatafromUserMaster();
        
        //Using the UserMaster data, set our custom claim types
        identity.AddClaim(new Claim(CustomClaimTypes.MasterUserId, userdata.UserId));
        identity.AddClaim(new Claim(CustomClaimTypes.MasterFullName, userdata.FullName));
        AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
    }
