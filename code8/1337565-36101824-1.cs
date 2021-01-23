    public class CompositionRoot : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {
            if (controllerType == typeof(OrderController))
            {
                return new OrderController(
                    new OrderService(
                        requestContext.HttpContext.User.Identity.Name));
            }
    
            // handle other Controller types here...
        }
    }
