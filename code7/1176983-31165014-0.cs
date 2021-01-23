    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public void Configuration(IAppBuilder app)
        {
           //other code
          
           OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
           app.UseOAuthBearerAuthentication(OAuthBearerOptions);
           //other code
        }
