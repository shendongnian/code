    class A { }
    class B : A { }
    class C
    {
        public B B = new B();
    }
    class Program
    {
        static void Main(string[] args)
        {
            var c = new C();
            var b = c.B;
            var BasA = (A)b;
            bool BisA = BasA.GetType() == typeof (A);
            Console.WriteLine($"Assert That B is not A: {!BisA}");
        }
    }
