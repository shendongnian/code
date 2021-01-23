    using System;
    namespace ConsoleApplication1
    {
        class C
        {
            public C Inner
            {
                get
                {
                    Console.WriteLine("Inner called.");
                    return this; // Change this to `return null;`
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var c = new C();
                var x = c?.Inner?.Inner?.Inner;
            }
        }
    }
