    class A
    {
        public void M(A a) { Console.WriteLine("A.M"); }
    }
    class B : A
    {
        public void M(B a) { Console.WriteLine("B.M"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            M(b);
        }
        static void M<T>(T t) where T : A
        {
            B b = new B();
            b.M(t);
        }
    }
