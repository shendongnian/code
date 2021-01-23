    public class ClientClass
    {
        private readonly IFooFactory fooFactory;
        public ClientClass(IFooFactory fooFactory)
        {
            this.fooFactory = fooFactory;
        }
        public void DoSomething()
        {
            var foo = fooFactory.CreateFoo();
           //Do whatever with foo
           //Your foo is now injected with another service and settings too:)
        }
    }
