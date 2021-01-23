    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) 
    { 
        loggerFactory.AddConsole(Configuration.GetSection("Logging")); 
        loggerFactory.AddDebug(); 
        app.UseMiddleware<RequestLoggingMiddleware>();
        
        // rest of the middlewares 
          ..................
        app.UseMvc(); 
    }
