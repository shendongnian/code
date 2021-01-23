    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
          loggerFactory.AddConsole(Configuration.GetSection("Logging"));
          loggerFactory.AddDebug();
          app.UseForwardedHeaders(new ForwardedHeadersOptions() { ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All }); // This must be first line. ( Before other middleware get configured)
          // your other code
        }
