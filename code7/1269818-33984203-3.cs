[assembly:OwinStartup(typeof(WebApplication3.Startup))]
    public class Startup
    {
                public void Configuration(IAppBuilder app)
                {
                    app.UseNancy();
                }
    }
