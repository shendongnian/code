	public class ServiceClient : IServiceClient 
    {
        private IComponentContext _container;
        public ServiceClient(IComponentContext container)
        {
            _container = container;
        }
        public ServiceCallWrapper<T> OfType<T>() where T : class, IDisposable
        {
            return new ServiceCallWrapper<T>(_container);
        }
    }
    public class ServiceCallWrapper<T> : IServiceCallWrapper<T> where T : class, IDisposable
    {
        private IComponentContext _container;
        internal ServiceCallWrapper(IComponentContext container)
        {
            _container = container;
        }
        public void Try(Action<T> method) 
        {
            // consider try/catch/log/throw here
            using (T client = _container.Resolve<T>())
            {
                method(client);
            }
        }
        public TResult Try<TResult>(Func<T, TResult> method)
        {
            using (T client = _container.Resolve<T>())
            {
                return method(client);
            }
        }
        public async Task TryAsync(Func<T, Task> method)
        {
            using (T client = _container.Resolve<T>())
            {
                await method(client);
            }
        }
        public async Task<TResult> TryAsync<TResult>(Func<T, Task<TResult>> method) 
        {
            using (T client = _container.Resolve<T>())
            {
                return await method(client);
            }
        }
    }
