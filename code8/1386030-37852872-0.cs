    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<LoggingMiddleware>();
            
            var config = new HttpConfiguration();
            //Move your WebApiConfig.Register here
            config.Services.Replace(typeof(IExceptionHandler), new WebApiExceptionPassthroughHandler())
            //Finally use your newly created config here
            app.UseWebApi(config);
        }
    }
