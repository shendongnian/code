    using System;
    namespace septtwenty
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i, number, fact;
                System.Console.WriteLine("Enter the Number");
                number = int.Parse(Console.ReadLine());
                fact = number;
                for (i = number -1; i>=1; i--)
                {
                    fact = fact * i;
                }
                System.Console.WriteLine("\nFactorial of Given Number is: "+fact);
                Console.ReadLine();
            }
        }
    }
