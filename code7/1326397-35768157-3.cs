    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // other owin config here...
            // Register Nancy with Owin middleware...
            app.UseNancy();
        }
    }
