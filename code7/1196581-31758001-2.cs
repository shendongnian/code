    using System;
    
    namespace MyApp
    {
        public class LargestNumber
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Enter a number:");
                int userNumber1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter a second number:");
                int userNumber2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter a third number:");
                int userNumber3 = int.Parse(Console.ReadLine());
    
                Console.WriteLine("Your numbers were, " + userNumber1 + ", " + userNumber2 + ", and " + userNumber3);
            }
        }
    }
