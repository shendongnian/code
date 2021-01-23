    public class Baz
    {
        private readonly IFoo foo;
    
        public Baz(IFoo foo)
        {
            this.foo = foo;
        }
        // Members using this.foo go here...
    }
