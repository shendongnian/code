    public void Configure(IAppBuilder appBuilder)
    {
        appBuilder.Use<WebRequestLifestyleMiddleware>();
        //
        // Further configuration
        //
    }
