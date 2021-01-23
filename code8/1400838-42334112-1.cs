    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApplicationDbContext myApplicationDbContext)
    {
        //...
        myApplicationDbContext.Seed();
    }
