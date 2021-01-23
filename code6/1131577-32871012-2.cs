    using System.Configuration;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.DataHandler.Encoder;
    using Microsoft.Owin.Security.Jwt;
    using Owin;
    
    [assembly: OwinStartupAttribute(typeof(TOMS.Frontend.Startup))]
    namespace TOMS.Frontend
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);
                ConfigureOAuthTokenConsumption(app);
            }
    
            private void ConfigureOAuthTokenConsumption(IAppBuilder app)
            {
                var issuer = ConfigurationManager.AppSettings["as:Issuer"];
                var audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
                var audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);
    
                // Api controllers with an [Authorize] attribute will be validated with JWT
                app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret) 
                    }
                });
            }
        }
    }
