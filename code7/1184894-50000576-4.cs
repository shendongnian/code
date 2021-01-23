        public class WindsorHttpDependencyResolver : IDependencyResolver
        {
            private readonly IWindsorContainer container;
    
            public WindsorHttpDependencyResolver(IWindsorContainer container)
            {
                if (container == null)
                {
                    throw new ArgumentNullException("container");
                }
                this.container = container;
            }
    
            public object GetService(Type t)
            {
                return this.container.Kernel.HasComponent(t)
                 ? this.container.Resolve(t) : null;
            }
    
            public IEnumerable<object> GetServices(Type t)
            {
                return this.container.ResolveAll(t).Cast<object>().ToArray();
            }
    
            public IDependencyScope BeginScope()
            {
                return new WindsorDependencyScope(this.container);
            }
    
            public void Dispose()
            {
            }
        }//end WindsorHttpDependencyResolver 
   
      public class WindsorDependencyScope : IDependencyScope
        {
            private readonly IWindsorContainer container;
            private readonly IDisposable scope;
    
            public WindsorDependencyScope(IWindsorContainer container)
            {
                if (container == null)
                    throw new ArgumentNullException("container");
    
                this.container = container;
            }
    
            public object GetService(Type t)
            {
                return this.container.Kernel.HasComponent(t)
                    ? this.container.Resolve(t) : null;
            }
    
            public IEnumerable<object> GetServices(Type t)
            {
                return this.container.ResolveAll(t).Cast<object>().ToArray();
            }
    
            public void Dispose()
            {
                this.scope?.Dispose();
            }
        }
