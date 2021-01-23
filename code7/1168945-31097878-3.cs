    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var config = new HttpConfiguration();
    
            builder.Use<GlobalExceptionMiddleware>();
            //register other middlewares
        }
    }
