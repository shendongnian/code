    using System;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var primes = Enumerable.Range(1, 100000)
                                   .AsParallel()
                                   .Where(IsPrime)
                                   .ToList();
            Console.WriteLine(primes.Count);
        }
        
        static bool IsPrime(int number)
        {
            if (number == 1) return false;
            // TODO: Only go up to Math.Sqrt(number)
            for (int j = 2; j < number; j++)
            {
                if (number % j == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
