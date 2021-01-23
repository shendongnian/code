    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Foo>("Foos");
            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
