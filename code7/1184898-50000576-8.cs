    public static class IoCResolverFactory
    {
        public static IoCResolver iocResolver;
        public static IoCResolver GetOrCreate()
        {
            if (iocResolver != null)
                return iocResolver;
            iocResolver = new IoCResolver();
            return iocResolver;
        }
    }// end IoCResolverFactory
    
    public class IoCResolver
    {
        private static WindsorContainer container;
        public IoCResolver()
        {
            container = new WindsorContainer();
            container.Register(Component.For<IoCResolver>().Instance(this).LifestyleSingleton());
            container.Register(Component.For<IWindsorContainer>().Instance(container).LifestyleSingleton());
        }
        public IDisposable BeginScope()
        {
            return container.BeginScope();
        }
        public IDisposable GetCurrentScope()
        {
            return Castle.MicroKernel.Lifestyle.Scoped.CallContextLifetimeScope.ObtainCurrentScope();
        }
        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
        public IList<T> ResolveAll<T>()
        {
            return container.ResolveAll<T>();
        }
        public void Dispose()
        {
            container.Dispose();
        }
    }
