    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        // completely disable logging or use one of the other levels, such as Error, Critical, Warning etc. 
        loggerFactory.MinimumLevel = LogLevel.None;
    }
