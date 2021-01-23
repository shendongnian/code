    var g = new GooglePlusAuthenticationOptions();
    g.ClientId = Constants.GoogleClientId;
    g.ClientSecret = Constants.GoogleClientSecret;
    g.RequestOfflineAccess = true;  // for refresh token
    g.Provider = new GooglePlusAuthenticationProvider
    {
        OnAuthenticated = context =>
        {
            context.Identity.AddClaim(new Claim(Constants.GoogleAccessToken, context.AccessToken));
            if (!String.IsNullOrEmpty(context.RefreshToken))
            {
                context.Identity.AddClaim(new Claim(Constants.GoogleRefreshToken, context.RefreshToken));
            }
            return Task.FromResult<object>(null);
        }
    };
    
    g.Scope.Add(Google.Apis.YouTube.v3.YouTubeService.Scope.YoutubeReadonly);
    g.SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie;
    app.UseGooglePlusAuthentication(g);
