    public class Program 
    {
        public void Main()
        {
            ServiceContainer.Register<IFoo>(() => new Foo()); /*register foo*/
        }
     
        public void UsingFoo()
        {
            var foo = ServiceContainer.Resolve<IFoo>(); /* do something with foo... */
        }
    }
