    public class MyActivator : IJobActivator
    {
        private readonly IUnityContainer _container;
        public MyActivator(IUnityContainer container)
        {
            _container = container;
        }
        public T CreateInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
