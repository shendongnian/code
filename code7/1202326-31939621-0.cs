    using System;
    
    namespace SomeFibonacciPrimes
    {
        class SomeFibonacciPrimes
        {
            static void Main()
            {
                Console.WriteLine("Enter a number to find if it's in Fibonacci      range:");
                int number = int.Parse(Console.ReadLine());
                if (IsFibonacci(number))
                {
                    Console.WriteLine("Your number is within the Fibonacci range.");
                }
                else
                {
                    Console.WriteLine("Your number is NOT within the Fibonacci range");
                }
           }
    	   
    	
		
            static bool IsFibonacci(int number)
    		{
    			//Uses a closed form solution for the fibonacci number calculation.
    			//http://en.wikipedia.org/wiki/Fibonacci_number#Closed-form_expression
    
    			double fi = (1 + Math.Sqrt(5)) / 2.0; //Golden ratio
    			int n = (int) Math.Floor(Math.Log(number * Math.Sqrt(5) + 0.5, fi)); //Find's the index (n) of the given number in the fibonacci sequence
    
    			int actualFibonacciNumber = (int)Math.Floor(Math.Pow(fi, n) / Math.Sqrt(5) + 0.5); //Finds the actual number corresponding to given index (n)
    
    			return actualFibonacciNumber == number;
    		}
        }
    }
