    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider svp)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
        System.Web.HttpContext.Configure(app.ApplicationServices.
            GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>()
        );
