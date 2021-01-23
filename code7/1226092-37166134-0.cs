    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      ...
      // Serve the default file, if present.
      app.UseDefaultFiles();
      app.UseStaticFiles();
      ...
    }
