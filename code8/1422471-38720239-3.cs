        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(CreateOptionsFromPolicy(signInPolicyId));
        }
 
     private OpenIdConnectAuthenticationOptions CreateOptionsFromPolicy(string policy)
        {
            
            return new OpenIdConnectAuthenticationOptions
            {
                MetadataAddress = string.Format(aadInstance, tenant, policy),
                AuthenticationType = policy,
                ClientId = clientId,
                RedirectUri = "https://localhost:44300/",
                PostLogoutRedirectUri = redirectUri,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                },
                Scope = "openid",
                ResponseType = "id_token",
                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                },
            };
        }
