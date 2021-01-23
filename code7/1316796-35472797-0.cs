     public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
     {
         app.Map("/MyVirtualApp", map => ConfigureMyVirtualApp(map, env, loggerFactory));
     }
     public void ConfigureMyVirtualApp(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
     {
         loggerFactory.MinimumLevel = LogLevel.Information;
         loggerFactory.AddConsole();
         loggerFactory.AddDebug();
         // Add the platform handler to the request pipeline.
         app.UseIISPlatformHandler();
         app.UseDefaultFiles();
         // Configure the HTTP request pipeline.
         app.UseStaticFiles();
     }
