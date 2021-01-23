    public class SomeClass
    {
        public void HandleSomething() {
            IFoo foo = FooFactory.Create();
            foo.DoSomething();
        }
    }
