    class A
    {
        private readonly B _b;
        public A(B b)
        {
            _b = b;
        }
    }
    class B
    {
        public B(Lazy<A> a)
        {
            this._a = a;
        }
        private readonly Lazy<A> _a;
    }
