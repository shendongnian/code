    using System;
    using System.Diagnostics;
    
    class Test
    {
        static volatile int a = a, b = 2, c = 3, d = 4, y = 5;
        static void Main(string[] args)
        {
            Debugger.Break();
            Debug.WriteLine("a > b:{0}", a > b);
            Debug.WriteLine("c > b:{0}", c > b);
            Debug.WriteLine("d < y:{0}", d < y);
            Debug.WriteLine("a > b && c > b && d < y:{0}", a > b && c > b && d < y);
            if (a > b && c > b && d < y)
            {
                Console.WriteLine("...");
            }
        }
    }
