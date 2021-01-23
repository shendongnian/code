    public class CustomEnableQueryAttribute : EnableQueryAttribute
    {
        public override IEdmModel GetModel(Type elementClrType, HttpRequestMessage request, HttpActionDescriptor actionDescriptor)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Event>("Events");
            return modelBuilder.GetEdmModel();
        }
    }
