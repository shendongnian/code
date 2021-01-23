    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        ...
        //Add CORS middleware before MVC
        app.UseCors("AllowAll");
        app.UseMvc(...);
    }
