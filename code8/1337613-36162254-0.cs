    using System.Web.Http;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.OAuth;
    using Owin;
    [assembly: OwinStartup(typeof(MyProject.Startup))]
    namespace MyProject
    {
        public class Startup
        {
            public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
    
            public void Configuration(IAppBuilder app)
            {
                var config = new HttpConfiguration();
    
                OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
                app.UseOAuthBearerAuthentication(OAuthBearerOptions);
    
                // Configure Web API to use only bearer token authentication.
                config.SuppressDefaultHostAuthentication();
                config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
    
                app.UseWebApi(config);
            }
        }
    }
