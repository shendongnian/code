	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.MapRoute(
			  "Root",
			  "",
			  defaults: new { controller = "Person", action = "Search" }
			);
			
			routes.MapMvcAttributeRoutes();
			
			// Place any other `MapRoute` declarations here
		}
	}
