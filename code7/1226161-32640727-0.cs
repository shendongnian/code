    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Find1000Primes
    {
        class Program
        {
            static void Main(string[] args)
            {
                int totalPrime = 0;
                int countPrime = 1000;
                int x = 0;  // counter for the primes
                int i = 0;  // each number that is checked starting with 0
                while (x < countPrime)
                {
                    bool prime = IsPrime(i);
                    if (prime)
                    {
                        totalPrime = totalPrime + i;
                        x++;
                    }
                    i++;
                }
                Console.WriteLine(totalPrime.ToString());
                Console.ReadLine();
            }
            public static bool IsPrime(int number)
            {
                if ((number & 1) == 0)
                {
                    if (number == 2)
                        return true;
                    else
                        return false;
                }
                for (int i = 3; (i*i) <= number; i+=2)
                {
                    if ((number % i) == 0)
                        return false;
                }
                return number != 1;
            }
        }
    }
  
