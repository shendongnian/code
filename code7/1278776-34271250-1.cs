    using System;
    
    class Test
    {
        static void Main()
        {
            object x = "abc";
            dynamic y = 10;
            
            Foo(x, y); // Prints Foo(object,int)
        }
        
        static void Foo(object x, int y)
        {
            Console.WriteLine("Foo(object,int)");
        }
        
        static void Foo(string x, int y)
        {
            Console.WriteLine("Foo(string,int)");
        }
    }
