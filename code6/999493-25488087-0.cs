    class Foo
    {
        public readonly int Bar; // Bar can only be initialized in the constructor
    
        public Foo()
        {
            this.Bar = 42;
        }
    }
