    public class ServiceFactory<B> : IServiceFactory<B>
    {
        private readonly IServiceFactory serviceFactory;
        public ServiceFactory(IServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
        }
        public T Get<T>() where T : B
        {
            return serviceFactory.Get<T>();
        }
        public T Create<T>(params object[] p) where T : B
        {
            return serviceFactory.Create<T>(p);
        }
    }
