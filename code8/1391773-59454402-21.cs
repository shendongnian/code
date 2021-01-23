    public class ServiceFactory : IServiceFactory
    {
        private readonly Func<Type, object> factory;
        public ServiceFactory(Func<Type, object> factory)
        {
            this.factory = factory;
        }
        // Get an object of type T where T is usually an interface
        public T Get<T>()
        {
            return (T)factory(typeof(T));
        }
    }
