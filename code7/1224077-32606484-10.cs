    app.UseMvc(routes =>
    {
        routes.Routes.Add(
           new CustomRoute(routes.ServiceProvider.GetRequiredService<IMemoryCache>(), 
                           routes.DefaultHandler));
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
        // Uncomment the following line to add a route for porting Web API 2 controllers.
        // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
    });
