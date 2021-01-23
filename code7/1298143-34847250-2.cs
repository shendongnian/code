    public void Configure(IApplicationBuilder app, 
                          IHostingEnvironment env, 
                          ILoggerFactory loggerFactory)
    {
        // This line can be removed if you are using 1.0.0-rc2 or higher
        loggerFactory.MinimumLevel = LogLevel.Debug;
        loggerFactory.AddConsole(LogLevel.Debug);
        // Configuring other middleware
    }
