    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        { 
            app.UseIISPlatformHandler(); //this line
            app.UseDefaultFiles();
            app.UseStaticFiles();            
            //app.UseMvc();
    
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action?}/{id?}");
    
            });
        }
