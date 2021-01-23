    class Foo : ISomeInterface
    {
        public int SomeProperty { get; private set; }
    
        public Foo()
        {
             SomeProperty = 42;
        }
    }
