    private async Task SignInAsync(ApplicationUser user, bool isPersistent)
    {
        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        // Add the users primary identity details to the set of claims.
        var your_profile = GetFromYourProfileTable();
        identity.AddClaim(new Claim(ClaimTypes.GivenName, id == null ? string.Empty : your_profile.FirstName));
        identity.AddClaim(new Claim(ClaimTypes.Surname, id == null ? string.Empty : your_profile.LastName));
        AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
    }
