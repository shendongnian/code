    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace PrimeNumberHelp
    {
        class Program
        {
            
            private static int Max = 100;
            static void Main(string[] args)
            {
                List<int> Primes = new List<int>();
                int current = 0;
                while (current <= 100)
                {
                    if (IsPrime(current))
                        Primes.Add(current);
                    current++;
                }
                Console.WriteLine(Primes[23]);
                Console.ReadKey();
            }
    
            private static bool IsPrime(int number)
            {
                if (number == 1)
                    return false;
                if (number == 2)
                    return true;
    
                if (number % 2 == 0)
                    return false;
    
                for (int i = 3; i * i <= number; i += 2)
                {
                    if (number % i == 0)
                        return false;
                }
                return true;
            }
        }
    }
