    public class WindsorControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null) 
            {
               throw new HttpException(404, "page not found");
            }
            return (IController)container.Resolve(controllerType);
        }
    }
