    public class UnityServiceProvider : IServiceProvider
    {
        private IUnityContainer _container;
        public IUnityContainer UnityContainer => _container;
        public UnityServiceProvider()
        {
            _container = new UnityContainer();
        }
        #region Implementation of IServiceProvider
        /// <summary>Gets the service object of the specified type.</summary>
        /// <returns>A service object of type <paramref name="serviceType" />.-or- null if there is no service object of type <paramref name="serviceType" />.</returns>
        /// <param name="serviceType">An object that specifies the type of service object to get. </param>
        public object GetService(Type serviceType)
        {
            //Delegates the GetService to the Containers Resolve method
            return _container.Resolve(serviceType);
        }
        #endregion
    }
