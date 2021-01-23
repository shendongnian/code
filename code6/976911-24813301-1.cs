    namespace Library
    {
        public interface IFoo { }
        // local Foo factory, with a customizable provider
        public class FooFactory
        {
            private static Func<IFoo> _provider;
            public static void SetProvider( Func<IFoo> provider )
            {
               _provider = provider;
            }
            public IFoo CreateFoo()
            {
                return _provider();
            }
        } 
        // Bar needs Foo
        public class Bar
        {
            public void Something()
            {
                // you can use the factory here safely
                // but the actual provider is configured elsewhere
                FooFactory factory = new FooFactory();
                
                IFoo foo = factory.CreateFoo();
            }
        }
    }
