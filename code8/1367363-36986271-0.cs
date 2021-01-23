    using System;
    
    namespace CalculateGCD
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
    
                Console.WriteLine(GCD(a,b));
            }
            
            static int GCD(int a, int b) 
            {
               return b == 0 ? a : GCD(b, a % b);
            }
    
        }
    }
