    [assembly: OwinStartup(typeof(MyProject.API.Startup))]
    
    namespace MyProject.API
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                app.UseWebApi(WebApiConfig.Register());
            }
         }
    }
