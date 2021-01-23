    public class SomeClass
    {
        private readonly IFooFactory fooFactory;
        public SomeClass(IFooFactory fooFactory) {
            this.fooFactory = fooFactory;
        }
        public void HandleSomething() {
            IFoo foo = this.fooFactory.Create();
            foo.DoSomething();
        }
    }
