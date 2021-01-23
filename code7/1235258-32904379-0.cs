    using System;
    
    class Test
    {
        static void Foo<T>(T item)
        {
            Console.WriteLine("Generic");
        }
        
        static void Foo(object x)
        {
            Console.WriteLine("Non-generic");
        }
        
        static void Main()
        {
            Foo(new object()); // Calls Foo(object)
            Foo("test"); // Calls Foo<T>(T)
        }
    }
