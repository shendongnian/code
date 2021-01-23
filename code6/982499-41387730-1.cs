    public class SecureAccessAttribute : EnableQueryAttribute
    {
        public override IEdmModel GetModel(Type elementClrType, HttpRequestMessage request, HttpActionDescriptor actionDescriptor)
        {
            bool includeOrders = /* Check if user can access orders */;
            return GetModel(includeOrders);
        }
    }
