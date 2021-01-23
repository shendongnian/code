    class Program
    {
        class A { public virtual void F() { Console.WriteLine("A"); } }
        class B : A { public override void F() { Console.WriteLine("B"); } }
        static void Main(string[] args)
        {
            A x;
            x = new B();
            x.F();
            Console.ReadLine();
        }
    }
