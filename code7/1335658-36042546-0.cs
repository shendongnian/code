	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			var company = System.Configuration.ConfigurationManager.AppSettings["DbCompany"];
			
			config.Routes.MapHttpRoute(
				name: "DoQuery",
				routeTemplate: "MyApp/"+ company +"/DoQuery",
				defaults: new { controller = "main", action = "DoQuery" }
			);
			
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "MyApp/"+ company +"/{id}",
				defaults: new { controller = "main" , id = RouteParameter.Optional }
			);
			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
		}
	}
