    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API configuration and services
            config.Filters.Add(new ValidateModelStateFilter());
    
            // Web API routes
            config.MapHttpAttributeRoutes();
    
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{action}/{id}",
                defaults: new { controller = "Menu", id = RouteParameter.Optional}
            );
    
            //FluentValidation
            FluentValidationModelValidatorProvider.Configure(config);
    
        }
    }
