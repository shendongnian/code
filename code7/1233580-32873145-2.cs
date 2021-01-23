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
                    // default config, you have to call your initializer here, if you want you can remove the lazy stuff, and make the container a property and set it where ever you init your Structuremap, for me that's IOC.cs - EWB
                } );
            }
        }
