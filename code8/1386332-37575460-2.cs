    public class DependencyResolverForControllerActionInvoker : IDependencyResolver
    {
        private readonly IDependencyResolver innerDependencyResolver;
        public DependencyResolverForControllerActionInvoker(IDependencyResolver innerDependencyResolver)
        {
            if (innerDependencyResolver == null)
                throw new ArgumentNullException("innerDependencyResolver");
            this.innerDependencyResolver = innerDependencyResolver;
        }
        public object GetService(Type serviceType)
        {
            if (typeof(IAsyncActionInvoker).Equals(serviceType) || typeof(IActionInvoker).Equals(serviceType))
            {
                return new MyAsyncControllerActionInvoker();
            }
            return this.innerDependencyResolver.GetService(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.innerDependencyResolver.GetServices(serviceType);
        }
    }
    public class MyAsyncControllerActionInvoker : AsyncControllerActionInvoker
    {
        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            try
            {
                return base.InvokeAction(controllerContext, actionName);
            }
            catch (HttpException ex)
            {
                // Handle unknown action error
            }
        }
        public override bool EndInvokeAction(IAsyncResult asyncResult)
        {
            try
            {
                return base.EndInvokeAction(asyncResult);
            }
            catch (HttpException ex)
            {
                // Handle unknown action error
            }
        }
    }
