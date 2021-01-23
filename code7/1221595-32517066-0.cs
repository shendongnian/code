    class Foo
    {
        private readonly int _a;
        private readonly string _b;
        public Foo(int a, string b)
        {
            _a = a;
            _b = b;
        }
        public int A { get { return _a; } }
        public string B { get { return _b; } }
    }
