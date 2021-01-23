    using System;
    
    namespace Scenario1_2
    {
        class Program
        { 
            static void Main(string[] args)
            {   
                Console.WriteLine("Please enter the number you wish to factorize");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("The number you entered was {0} and it's factorial is {1}", number, Factorials().Skip(number-1).First());
                Console.ReadKey(true);
            }
            static IEnumerable<int> Factorials()
            {
                int n = 1, f = 1;
                while (true) yield return f = f * n++;
            } 
        }
    }
