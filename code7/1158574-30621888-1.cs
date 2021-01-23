    public class FooAdapter : IFoo
    {
        private readonly IFoo foo;
        
        public FooAdapter(IFoo foo)
        {
            this.foo = foo;
        }
        
        public void Method1()
        {
            this.foo.Method1();
        }
        
        public void Method2()
        {
            Console.WriteLine("I am Method2 of FooAdapter");
        }
    }
