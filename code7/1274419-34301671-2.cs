    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            //config.MapHttpAttributeRoutes();
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("customers");
            config.MapODataServiceRoute(
                routeName: "OData",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
