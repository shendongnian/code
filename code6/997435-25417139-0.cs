    using System;
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("This program screens all numbers between 1 and 100 for primes and displays the results.");
    
            for (var numberToPrimeCheck = 2; numberToPrimeCheck <= 100; numberToPrimeCheck++)
            {
                for (var divisor = 2; divisor <= Math.Sqrt(numberToPrimeCheck); divisor++)
                {
                    var remainder = 0;
                    remainder = numberToPrimeCheck % divisor;
                    if (remainder != 0)
                    {
                        Console.WriteLine(numberToPrimeCheck);
                        break;
                    }
                }
            }
        }
    }
