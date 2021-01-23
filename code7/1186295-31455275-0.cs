    public class CheckoutPrefixRouteProvider : DefaultDirectRouteProvider
    {
        protected override string GetRoutePrefix(ControllerDescriptor controllerDescriptor)
        {
            return "checkout/" + base.GetRoutePrefix(controllerDescriptor);
        }
    }
