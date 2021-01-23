	public static void ConfigureApp(IAppBuilder appBuilder)
    {
		...
		var service = (JsonSerializer)GlobalHost.DependencyResolver.GetService(typeof(Newtonsoft.Json.JsonSerializer));
        service.TypeNameHandling = TypeNameHandling.All;
		...
	}
