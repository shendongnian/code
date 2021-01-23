    class Foo
    {
        public DateTime Created { get; } = DateTime.Now;  // construction timestamp
        public int X { get; } 
        public Foo(int n)
        {
            X = n;  // writeable in constructor only
        }
    }
