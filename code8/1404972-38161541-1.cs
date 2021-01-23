    public void Configuration(IAppBuilder app)
        {
                ConfigureOAuthTokenConsumption(app);
        }
        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["AuthIssuer"];
            string audienceid = ConfigurationManager.AppSettings["AudienceId"];
            byte[] audiencesecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["AudienceSecret"]);
            app.UseCookieAuthentication(new CookieAuthenticationOptions { CookieName = "AuthCookie" , AuthenticationType=DefaultAuthenticationTypes.ApplicationCookie });
            //// Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Passive,
                    AuthenticationType = "JWT",
                    AllowedAudiences = new[] { audienceid },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audiencesecret)                           
                    }
                    
                });
        }
