    using System;
    namespace ConsoleApp
    {
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter A Number :");
            n = int.Parse(Console.ReadLine());
            if (n % 3 == 0 && n % 5 == 0)
            {
                Console.WriteLine("This Number is Divisible by 3 and 5 ");
            }
            else
            {
                Console.WriteLine("This Number is Not Divisible by 3 and 5");
            }
            Console.ReadLine();
        }
    }
    }
