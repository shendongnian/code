    public class Startup
    {
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env, 
                              ILoggerFactory loggerfactory)
        {
           app.UseMiddleWare<ExceptionHandlerMiddleware>
        }
    }
