    public class MyDryIocDependencyResolver : IDependencyResolver { 
        IDependencyResolver innerResolver;
    
        public MyCustomDependencyResolver(IDependencyResolver innerResolver) {
            this.innerResolver = innerResolver;
        }
    
        public IDependencyScope BeginScope() {
            return this;
        }
    
        public object GetService(Type serviceType) {
            object result = innerResolver.Getservice(serviceType);
            if(result == null)
                throw new Exception(string.Format("couldn't resolve {0}", serviceType.Name);
            return result;
        }
        
        public IEnumerable<object> GetServices(Type serviceType) {
            IEnumerable<object> result = innerResolver.GetServices(serviceType);
            if(result == null)
                throw new Exception(string.Format("couldn't resolve {0}", serviceType.Name);
            return result;
        }
        
        public void Dispose() {
          // NO-OP 
        }
    }
