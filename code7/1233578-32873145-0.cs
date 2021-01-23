    public static class JcdcObjectFactory
        {
            private static readonly Lazy<Container> _containerBuilder =
                new Lazy<Container>( defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication );
    
    
            public static T GetInstance<T>()
            {
                return Container.GetInstance<T>();
            }
    
            public static IContainer Container
            {
                get { return _containerBuilder.Value; }
            }
    
            private static Container defaultContainer()
            {
                return new Container( x =>
                {
                    // default config
                } );
            }
        }
