    using System;
    namespace Scenario1_2
    {
        class Program
        { 
            static void Main(string[] args)
            {
               int counter, number, fact;
               Console.WriteLine("Please enter the number you wish to factorize");
               number = int.Parse(Console.ReadLine());
               fact = number;
               for (counter = number - 1; counter >= 1; counter--)
               {
                   fact = fact * counter; 
               }
               Console.WriteLine("The number you entered was {0} and it's factorial is {1}", number, fact);
               Console.ReadLine();
            } 
        }
    }
