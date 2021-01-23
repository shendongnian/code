     public class Startup
            {
                public void Configuration(IAppBuilder app)
                {
                    
                    app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                    app.UseWebApi(WebApiConfig.Register());
                }
        }
