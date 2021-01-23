    private async Task StoreGooglePlusAuthToken(ApplicationUser user)
    {
        var claimsIdentity = await AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie);
        if (claimsIdentity != null)
        {
            // Retrieve the existing claims for the user and add the google plus access token
            var currentClaims = await UserManager.GetClaimsAsync(user.Id);
            var ci = claimsIdentity.FindAll(Constants.GoogleAccessToken);
            if (ci != null && ci.Count() != 0)
            {
                var accessToken = ci.First();
                if (currentClaims.Count() <= 0)
                {
                    await UserManager.AddClaimAsync(user.Id, accessToken);
                }
            }
            ci = claimsIdentity.FindAll(Constants.GoogleRefreshToken);
            if (ci != null && ci.Count() != 0)
            {
                var refreshToken = ci.First();
                if (currentClaims.Count() <= 1)
                {
                    await UserManager.AddClaimAsync(user.Id, refreshToken);
                }
            }
        }
