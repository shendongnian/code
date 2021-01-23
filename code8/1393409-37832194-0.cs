    public static class WindsorContainerExtensions
        {            
            public static void Override<TService>(this IWindsorContainer container, TService instance) where TService : class
            {
                container.Register(Component.For<TService>().Instance(instance).IsDefault());
            }
        }
 
