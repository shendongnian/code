    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
          loggerFactory.AddConsole(Configuration.GetSection("Logging"));
          loggerFactory.AddDebug();
          app.UseForwardedHeaders(); // This must be first line. ( Before other middleware get configured)
          // your other code
        }
