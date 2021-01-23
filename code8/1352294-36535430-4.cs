    using Microsoft.Owin;
    using Microsoft.Owin.Security.OAuth;
    using Owin;
    using System;
    
    [assembly: OwinStartup(typeof(WebApplication1.Startup))]
    
    namespace WebApplication1
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                app.UseWebApi(config);
            }
       }
    }
