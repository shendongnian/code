    public void Configure(IApplicationBuilder application)
    {
        // Add static files to the request pipeline.
        application.UseStaticFiles();
        // Add MVC to the request pipeline.
        application.UseMvc();
    }
