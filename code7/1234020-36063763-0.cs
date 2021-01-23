    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        if (env.IsDevelopment())
        {
	        app.Use(async (context, next) =>
            {
                 try
                 {
                      await next();
                 }
                 catch (Exception ex)
                 {
                      if (context.Response.HasStarted)
                      {
                          throw;
                      }
                      context.Response.StatusCode = 500;
                      await context.Response.WriteJsonExcpetionAsync(ex);
                  }
            });
        }
	    // Other config logic...
    }
