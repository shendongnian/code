        public static string clientIds = ConfigurationManager.AppSettings["ValidClientIds"];
        public void ConfigureAuth(IAppBuilder app)
        {
            TokenValidationParameters tvps = new TokenValidationParameters
            {
                // This is where you specify that your API accepts tokens only from its own clients
                ValidAudiences = clientIds.Split(',')
            };
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                // This SecurityTokenProvider fetches the Azure AD B2C metadata and signing keys from the OpenID Connect metadata endpoint
                AccessTokenFormat = new JwtFormat(tvps, new OpenIdConnectCachingSecurityTokenProvider(String.Format(aadInstance, tenant, Globals.ODICEndpointVersion, Globals.OIDCMetadataSuffix, commonPolicy)))
            });
        }
