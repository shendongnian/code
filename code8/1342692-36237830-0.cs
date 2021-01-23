        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Do you really want to quit the Game? (y, n): ");
                char YN = Console.ReadLine()[0];
                if (YN == 'y' ||
                    YN == 'Y')
                {
                    Environment.Exit(0);
                }
                else if (YN == 'n' ||
                     YN == 'N')
                {
                    Console.WriteLine("Continue Game...");
                }
            }
        }
    }
