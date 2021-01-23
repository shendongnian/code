	public static void RegisterRoutes(RouteCollection routes)
	{
		routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
		routes.MapRoute(
			name: "Username_Default",
			url: "{username}/{controller}/{action}/{id}",
			defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
			constraints: new { username = new OwinUsernameConstraint() }
		);
		
		routes.MapRoute(
			name: "Default",
			url: "{controller}/{action}/{id}",
			defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
		);
	}
