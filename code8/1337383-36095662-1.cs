    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        //add NLog to aspnet5
        loggerFactory.AddNLog();
        //add NLog.Web (only needed if NLog.Web.ASPNET5 is needed)
        app.AddNLogWeb();
        //configure nlog.config in your project root
        env.ConfigureNLog("nlog.config");
    }
