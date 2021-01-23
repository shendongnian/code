    public class Sut
    {
        private readonly IFoo foo;
        public Sut(IFoo foo)
        {
            this.foo = foo;
        }
    
        public IFoo Foo
        {
            get { return this.foo; }
        }
    }
