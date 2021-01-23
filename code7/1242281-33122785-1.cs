    public class UnityControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type controllerType = null;
            if (TypeHelper.LooksLikeTypeName(controllerName))
            {
                controllerType = TypeHelper.GetType(controllerName);
            }
            if (controllerType == null)
            {
                controllerType = this.GetControllerType(requestContext, controllerName);
            }
            return controllerType != null ? this.GetControllerInstance(requestContext, controllerType) : null;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
                if (controllerType == null)
                    throw new ArgumentNullException("controllerType");
                if (!typeof(IController).IsAssignableFrom(controllerType))
                    throw new ArgumentException(string.Format(
                        "Type requested is not a controller: {0}",
                        controllerType.Name),
                        "controllerType");
                return MvcUnityContainer.Container.Resolve(controllerType) as IController;
            }
            catch
            {
                return null;
            }
        }
    }
    public static class MvcUnityContainer
    {
        public static IUnityContainer Container { get; set; }
    }
