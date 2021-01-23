    [assembly: OwinStartup(typeof(Startup))]
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            try
            {
                //
                // various app.Use() statements here to configure
                // OWIN middleware
                //
            }
            catch (Exception ex)
            {
              app.Use(new FailedSetupMiddleware(ex).Invoke);
            }
        }
    }
