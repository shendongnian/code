      public sealed class ServiceProviderDomainObjectFactory<T> : IDomainObjectFactory<T>
        {
            private  IServiceProvider provider;
    
            public void SetProvider(IServiceProvider provider)
            {
                this.provider = provider;
            }
    
            public ServiceProviderDomainObjectFactory()
            {
                
            }
    
            public T CreateNew<T>(string id)
            {
                var test = ActivatorUtilities.CreateInstance<T>(id,provider);
                return (T1) test;
            }
      }
