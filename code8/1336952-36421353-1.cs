        public void ConfigureAuth(IAppBuilder app)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = AuthenticationHelper.ClientId,
                    Authority = AuthenticationHelper.AadInstance + AuthenticationHelper.TenantId,
                    PostLogoutRedirectUri = AuthenticationHelper.PostLogoutRedirectUri,
                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        // If there is a code in the OpenID Connect response, redeem it for an access token and refresh token, and store those away.
                       AuthorizationCodeReceived =async (context) => 
                       {
                           var code = context.Code;
                           string signedInUserID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                           try
                           {
                               var result = await AuthenticationHelper.GetAccessTokenByCodeAsync(signedInUserID, code);
                           }
                           catch (Exception ex)
                           {
                               Debug.WriteLine(ex.Message);
                               //throw;
                           }
                           
                       }
                    }
                });
        }
 
