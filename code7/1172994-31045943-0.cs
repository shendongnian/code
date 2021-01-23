    internal static class Extension
    {
        public static int Foo(this A.B b)
        {
            return b.Ib;
        }
    }
    internal class A
    {
        public int Ia { get; set; }
        internal class B
        {
            public int Ib { get; set; }
        }
    }
