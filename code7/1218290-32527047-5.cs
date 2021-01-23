    public class WindsorControllerFactory : DefaultControllerFactory
    {
        // Fields
        private readonly IKernel _kernel;
        // Methods
        public WindsorControllerFactory(IKernel kernel)
        {
            if (kernel == null)
                throw new ArgumentNullException("kernel");
            _kernel = kernel;
        }
        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            if (controllerType == null)
                throw new HttpException(0x194,
                    string.Format(
                        "The controller for path '{0}' could not be found or it does not implement IController.",
                        context.HttpContext.Request.Path));
            return (IController) _kernel.Resolve(controllerType);
        }
    }
