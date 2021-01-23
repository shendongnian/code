     public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", "odata", model: GetEdmModel());
        }
        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<ListedBuildingResponseModel>("Buildings");
            builder.EnableLowerCamelCase();
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
