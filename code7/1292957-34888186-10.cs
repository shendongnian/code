    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        //add NLog to .NET Core
        loggerFactory.AddNLog();
    
        //Enable ASP.NET Core features (NLog.web) - only needed for ASP.NET Core users
        app.AddNLogWeb();
    
        //needed for non-NETSTANDARD platforms: configure nlog.config in your project root. NB: you need NLog.Web.AspNetCore package for this. 
        env.ConfigureNLog("nlog.config");
        ...
        //you could use LogManager.Configuration from here
    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        // e.g. services.AddMvc();
    
        //needed for NLog.Web
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
