    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var config = new HttpConfiguration();
            
            //register middlewares that don't need global exception handling. 
            builder.Use<GlobalExceptionMiddleware>();
            //register other middlewares
        }
    }
