    interface IHasMethodb
    {
        void b();
    }
    class A : IHasMethodb
    {
        public void b() { ... }
    }
    class B : IHasMethodb
    {
        A m;
        public void b() { return m.b(); }
    }
