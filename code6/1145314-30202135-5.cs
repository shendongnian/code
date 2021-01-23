    internal interface IA
    {
    }
    class A : IA
    {
    }
    internal interface IB
    {
        IA A { get; set; }
    }
    class B : IB
    {
        public B(IA a)
        {
            A = a;
        }
        public IA A { get; set; }
    }
    class C1
    {
        public IA A { get; set; }
        public IB B { get; set; }
        public C1(IA a, IB b)
        {
            A = a;
            B = b;
        }
    }
