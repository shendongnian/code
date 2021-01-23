    using System;
    
    using System.Collections.Generic;
    
    using System.Linq;
    
    using System.Text;
    
    namespace ConsoleApplication1 
    {
        class Program
        {
            public static void Fibonacci_Iterative(int n)
            {
               int a = 0, b = 1, c = 0;
               Console.Write("{0} {1}", a, b);
    
               for (int i = 2; i < n; i++)
               {
                   c = a + b;
                   Console.Write(" {0}", c);
                
                   a = b;
                   b = c;
    
               }
           }
    
        static void Main(string[] args)
        {
           Fibonacci_Iterative(15);
           Console.ReadKey();
        }
      }
    }
