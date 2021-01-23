    public class Startup {
        public void Configuration(IAppBuilder app) {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            GlobalHost.Configuration.DefaultMessageBufferSize = 100;
            ConfigureOAuth(app);
            app.MapSignalR();
        }
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public void ConfigureOAuth(IAppBuilder app) {
            OAuthOptions = new OAuthAuthorizationServerOptions {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(7)
            };
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
