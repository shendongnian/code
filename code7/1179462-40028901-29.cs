    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider svp)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
        ServiceProvider = svp;
        System.Web.HttpContext.ServiceProvider = svp;
        System.Web.Hosting.HostingEnvironment.m_IsHosted = true;
        
        app.UseCookieAuthentication(new CookieAuthenticationOptions()
        {
            AuthenticationScheme = "MyCookieMiddlewareInstance",
            LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Unauthorized/"),
            AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Forbidden/"),
            AutomaticAuthenticate = true,
            AutomaticChallenge = true,
            CookieSecure = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest
           , CookieHttpOnly=false
         
        });
