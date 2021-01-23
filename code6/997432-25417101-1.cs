    using System;
    
    class Prime_Screening {
        bool prime;
        static void Main()
            {
            Console.WriteLine("This program screens all numbers between 1 and 100 for primes and displays the results.");
    
                for (int numberToPrimeCheck = 2; numberToPrimeCheck <= 100; numberToPrimeCheck++)
                {
                    prime = True;
                    for (int divisor = 2; divisor <= Math.Sqrt(numberToPrimeCheck); divisor++)
                    {
                        if(numberToPrimeCheck % divisor == 0)
                            prime = False;
                    }
                    if (prime)
                    {
                        Console.Write(numberToPrimeCheck.ToString() + ", ");
                    }
                }
                // You can get rid of the trailing ", " if you want
            } 
        }
