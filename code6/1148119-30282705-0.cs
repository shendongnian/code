    using System;
   
    class Test
    {
        static void Foo(int x, int y)
        {
            Console.WriteLine("Foo(int x, int y)");
        }
    
        static void Foo(int x, double y)
        {
            Console.WriteLine("Foo(int x, double y)");
        }
    
        static void Foo(double x, int y)
        {
            Console.WriteLine("Foo(double x, int y)");
        }
        
        static void Main()
        {
            Foo(5, 10);
        }
    }
