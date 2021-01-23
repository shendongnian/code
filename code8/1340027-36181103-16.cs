    public class MyDryIocDependencyResolver : IDependencyResolver { 
        IDependencyResolver innerResolver;
    
        public MyCustomDependencyResolver(IDependencyResolver innerResolver) {
            this.innerResolver = innerResolver;
        }
    
        public IDependencyScope BeginScope() {
            return this;
        }
    
        public object GetService(Type serviceType) {
            try {
                return innerResolver.Getservice(serviceType);
            } catch (Exception ex) {
                //TODO: Log resolution error
                return null;
            }
        }
        
        public IEnumerable<object> GetServices(Type serviceType) {
            try {
                return innerResolver.GetServices(serviceType);
            } catch (Exception ex) {
               //TODO: Log resolution error
               return new List<object>();
            }
        }
        
        public void Dispose() {
          // NO-OP 
        }
    }
