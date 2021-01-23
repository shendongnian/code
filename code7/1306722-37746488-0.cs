    using System;
    
    class Test
    {
        static void Foo(Action action) {}
        static void Foo(Func<int> func) {}
        static int Bar() { return 1; }
        
        static void Main()
        {
            Foo(Bar);        
        }
    }
