    private async Task SignInAsync(ApplicationUser user, bool isPersistent)
    {
        var identity = await UserManager.CreateIdentityAsync(user,
        DefaultAuthenticationTypes.ApplicationCookie);
        AuthenticationManager.SignIn(new AuthenticationProperties() {
        IsPersistent = isPersistent }, identity);
    }
