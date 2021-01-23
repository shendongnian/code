    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
        loggerFactory.CreateLogger("Startup")                     // add
            .LogInformation($"Startup: {env.EnvironmentName}");   // this
        ...
    }
