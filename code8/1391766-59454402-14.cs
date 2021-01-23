    public class ServiceFactory : IServiceFactory
    {
        private readonly Func<Type, object> factory;
        private readonly Func<Type, object[], object> creator;
        public ServiceFactory(Func<Type, object> factory, Func<Type, object[], object> creator)
        {
            this.factory = factory;
            this.creator = creator;
        }
        // Get an object of type T where T is usually an interface
        public T Get<T>()
        {
            return (T)factory(typeof(T));
        }
        // Create (an obviously transient) object of type T, with runtime parameters 'p'
        public T Create<T>(params object[] p)
        {
            IService<T> lookup = Get<IService<T>>();
            return (T)creator(lookup.Type(), p);
        }
    }
