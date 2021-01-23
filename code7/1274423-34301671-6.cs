    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("customers");
            config.MapODataServiceRoute(
                routeName: "OData",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
