    using System;
    namespace helloworldwcond
    {
        class Program
        {
            public static void Main(string[] args)
            {
                int a;
                int b;
                int c;
                Console.Write("Enter a Number: ");
                a = int.Parse(Console.ReadLine());
                Console.Write("Enter another Number: ");
                b = int.Parse(Console.ReadLine());
                c = a + b;
                if (c == 7)
                {
                    Console.WriteLine("Hello World!");
                }
                else
                {
                    Console.Write("We Are DOOMED");
                }
                // TODO: Implement Functionality Here
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }
    }
