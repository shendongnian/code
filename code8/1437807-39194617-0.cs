    public void Configuration(IAppBuilder app)
    {
        var oauthProvider = new OAuthAuthorizationServerProvider
        {
            OnGrantClientCredentials = async context =>
            {
                   
                var claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                // based on clientId get roles and add claims
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Developer"));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Developer2"));
                context.Validated(claimsIdentity);
            },
            OnValidateClientAuthentication = async context =>
            {
                string clientId;
                string clientSecret;
                // use context.TryGetBasicCredentials in case of passing values in header
                if (context.TryGetFormCredentials(out clientId, out clientSecret))
                {
                    if (clientId == "clientId" && clientSecret == "secretKey")
                    {
                        context.Validated(clientId);
                    }
                }
            }
        };
        var oauthOptions = new OAuthAuthorizationServerOptions
        {
            AllowInsecureHttp = true,
            TokenEndpointPath = new PathString("/accesstoken"),
            Provider = oauthProvider,
            AuthorizationCodeExpireTimeSpan = TimeSpan.FromMinutes(1),
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(3),
            SystemClock = new SystemClock()
        };
        app.UseOAuthAuthorizationServer(oauthOptions);
        app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        var config = new HttpConfiguration();
        config.MapHttpAttributeRoutes();
        app.UseWebApi(config);
    }
