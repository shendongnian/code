	public class WebApiConfig
	{
		public static void Configure(IAppBuilder app)
		{
			var httpConfig = new HttpConfiguration();
		
			// Attribute routing
			config.MapHttpAttributeRoutes();
			// Redirect root to Swagger UI
			config.Routes.MapHttpRoute(
				name: "Swagger UI",
				routeTemplate: "",
				defaults: null,
				constraints: null,
				handler: new RedirectHandler(message => SwaggerDocsConfig.DefaultRootUrlResolver, "swagger/ui/index"));
		
			// Configure OWIN with this WebApi HttpConfiguration
			app.UseWebApi(httpConfig);
		}
    }
