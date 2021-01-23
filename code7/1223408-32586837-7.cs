	// Add MVC to the request pipeline.
	app.UseMvc(routes =>
	{
		routes.Routes.Add(
			new CachedRoute<int>(
				controller: "Cms",
				action: "Index",
				dataProvider: new CmsCachedRouteDataProvider(), 
				cache: routes.ServiceProvider.GetService<IMemoryCache>(), 
				target: routes.DefaultHandler)
			{
				CacheTimeoutInSeconds = 900
			});
		routes.MapRoute(
			name: "default",
			template: "{controller=Home}/{action=Index}/{id?}");
		// Uncomment the following line to add a route for porting Web API 2 controllers.
		// routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
	});
