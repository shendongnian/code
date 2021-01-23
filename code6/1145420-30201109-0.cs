    public void Configure(IApplicationBuilder app)
    {
        // Add static files to the request pipeline.
        app.UseStaticFiles();
     
        // Add cookie-based authentication to the request pipeline.
        app.UseIdentity();
     
        // Add MVC and routing to the request pipeline.
        app.UseMvc(routes =>
        {
        routes.MapRoute(
            name: "default",
            template: "{controller}/{action}/{id?}",
            defaults: new { controller = "Home", action = "Index" });
     
    });
