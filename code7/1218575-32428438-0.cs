    public class CustomGoogleLoginProvider : GoogleLoginProvider
    {
        public CustomGoogleLoginProvider(HttpConfiguration config, IServiceTokenHandler tokenHandler)
            : base(config, tokenHandler)
        {
            
        }
        
        public override void ConfigureMiddleware(IAppBuilder appBuilder, ServiceSettingsDictionary settings)
        {
            var options = new GoogleOAuth2AuthenticationOptions
            {
                ClientId = settings["MS_GoogleClientID"],
                ClientSecret = settings["MS_GoogleClientSecret"],
                AuthenticationType = this.Name,
                Provider = new CustomGoogleLoginAuthenticationProvider()
            };
            appBuilder.UseGoogleAuthentication(options);
        }
    }
    public class CustomGoogleLoginAuthenticationProvider : GoogleLoginAuthenticationProvider
    {
        public override Task Authenticated(GoogleOAuth2AuthenticatedContext context)
        {
            var result = base.Authenticated(context);
            var owin = HttpContext.Current.GetOwinContext();
            var auth = owin.Authentication;
            var identity = auth.User.Identity as ClaimsIdentity;
            //
            // store things I want in the database
            //
            return result;
        }
    }
