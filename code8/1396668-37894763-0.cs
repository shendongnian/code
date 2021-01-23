        static void Main(string[] args)
        {
            char computerPackage;
            const decimal DELUXE_PACKAGE = 1500;
            const decimal SUPER_PACKAGE = 1700;
            Console.Write("Input the Computer Package D or S: ");
            string inp = Console.ReadLine();
            if (inp.Length>0)
            {
                computerPackage = Char.Parse(inp);
                computerPackage = Char.ToUpper(computerPackage);
                if (computerPackage == 'D')
                {
                    Console.WriteLine("Cost of Deluxe Computer Package is " + DELUXE_PACKAGE.ToString("C"));
                }
                else if (computerPackage == 'S')
                {
                    Console.WriteLine("Cost of Deluxe Computer Package is " +
                    SUPER_PACKAGE.ToString("C"));
                }
                else
                {
                    Console.WriteLine("Package D or S not entered");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            
        }
