	public static class WebApiConfig
	{
		/// <summary>
		/// Registers the WebAPI routes.
		/// </summary>
		/// <param name="config">The configuration.</param>
		public static void Register(HttpConfiguration config)
		{
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "SOAInboundApi",
				routeTemplate: "api/{controller}",
				defaults: new { controller = "SOAInbound", action = "Post", id = RouteParameter.Optional }
			);
			config.Routes.MapHttpRoute(
				name: "LogFileApi",
				routeTemplate: "api/{controller}",
				defaults: new { controller = "LogFile", action = "Get", id = RouteParameter.Optional }
			);
		}
	}
