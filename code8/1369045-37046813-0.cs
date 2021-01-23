    struct A : IB
    {
        public void Method() { Console.WriteLine("1"); }   // Method defined in interface IB. 
        public void Method2() { Console.WriteLine("2"); }  // Method only in A
    }
    class Program
    {
        static void Main()
        {
            A a;
            a.Method();
            a.Method2();  // This works. 
            IB i = a;
            i.Method();
            i.Method2();// This fails to compile because Method2 isnt defined in the interface. 
        }
    }
