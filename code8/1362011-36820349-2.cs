    class Foo
    {
        public DateTime When { get; } = DateTime.Now;  // construction timestamp
        public int X { get; } 
        public Foo(int n)
        {
            X = n;
        }
    }
