    public void Configure(IApplicationBuilder app)  
    {
        app.UseStaticFiles();
        var options = 
        app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(options.Value);
        app.UseMvc(routes =>
        {
             routes.MapRoute(
                 name: "default",
                 template: "{controller=Home}/{action=Index}/{id?}");
        });
    }
    
