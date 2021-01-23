    public sealed class UnityControllerActivator : IHttpControllerActivator
    {
        private readonly UnityContainer container;
        public UnityControllerActivator(UnityContainer container) {
            this.container = container;
        }
        public IHttpController Create(HttpRequestMessage request, 
            HttpControllerDescriptor controllerDescriptor, Type controllerType) {
            // Make sure there is an active scope before calling resolve.
            request.GetDependencyScope();
            return (IHttpController)this.container.Resolve(controllerType);
        }
    }
