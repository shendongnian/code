    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;
    using System.Configuration;
    using System.Web.Mvc;
    using System.Web.Routing;
    
    [assembly: OwinStartup("MyStartup", typeof(MySolution.MyStartup))]
    namespace MySolution
    {
        public class MyStartup : Umbraco.Web.UmbracoDefaultOwinStartup
        {
            public override void Configuration(IAppBuilder app)
            {
                // Let Umbraco do its thing
                base.Configuration(app);
    
                // Call the authentication configration process (located in App_Start/Startup.Auth.cs)
                ConfigureAuth(app);
    
                // Hook up Auth0 controller
                RouteTable.Routes.MapRoute(
                    "Auth0Account",
                    "Auth0Account/{action}",
                    new
                    {
                        controller = "Auth0Account"
                    }
                );
            }
    
            private void ConfigureAuth(IAppBuilder app)
            {
                // Enable the application to use a cookie to store information for the signed in user
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Member/Login") // Use whatever page has your login macro lives on
                });
    
                // Use a cookie to temporarily store information about a user logging in with a third party login provider
                app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
                
                app.UseAuth0Authentication(
                    clientId: ConfigurationManager.AppSettings["auth0:ClientId"],
                    clientSecret: ConfigurationManager.AppSettings["auth0:ClientSecret"],
                    domain: ConfigurationManager.AppSettings["auth0:Domain"]);
            }
        }
    }
