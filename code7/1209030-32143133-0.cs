	public static void RegisterRoutes(RouteCollection routes)
	{
		routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        // Passing the URL `/Stuff` will match this route and cause it
        // to look for a controller named `StuffController` with action named `Index`.
		routes.MapRoute(
			name: "Default",
			url: "{controller}/{action}/{id}",
			defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
		);
	}
