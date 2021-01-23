    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public void Configuration(IAppBuilder app)
        {
           //other code
          
           OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions();
           app.UseOAuthAuthorizationServer(OAuthServerOptions); 
           OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
           app.UseOAuthBearerAuthentication(OAuthBearerOptions);
           //other code
        }
