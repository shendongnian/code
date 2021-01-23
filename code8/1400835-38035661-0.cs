    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        //...
        // Put this at the end of your configure method
        DbContextSeedData.Seed(app);
    }
