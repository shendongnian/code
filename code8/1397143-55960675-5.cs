        class DependencyInjectionRoot
        {
            private readonly IKeyedFactory<Source, IVerificationHandler> _factory;
             public DependencyInjectionRoot(IKeyedFactory<Source, IVerificationHandler> factory)
            {
                _factory = factory;
            }
             public void AccessDependency(Source key)
            {
                IVerificationHandler dependency = _factory.Get(key);
            }
        }
         public void ResolutionWithDependencyInjection()
        {
            var container = new Container();
            //...Register factory
            container.Register<DependencyInjectionRoot>();
            var dependencyRoot = container.GetInstance<DependencyInjectionRoot>();
            dependencyRoot.AccessDependency(Source.Remote);
        }
         public void ResolutionWithDirectContainerAccess()
        {
            var container = new Container();
            //...Register factory
            var factory = container.GetInstance<IKeyedFactory<Source, IVerificationHandler>>();
            var resolvedInstance = factory.Get(Source.Remote);
        }
         public void ResolutionWithDirectContainerAccessUsingExtensionMethod()
        {
            var container = new Container();
            //...Register factory
            var resolvedInstance = container.GetInstance<IKeyedFactory<Source, IVerificationHandler>, Source, IVerificationHandler>(Source.Remote);
        } 
