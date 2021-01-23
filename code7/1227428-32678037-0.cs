     static void Main(string[] args)
        {
            string input = "";
            input = Console.ReadLine();
            while (input != string.Empty)
            {
                if (input.Contains("problem"))
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
                input = Console.ReadLine();
            }
            Console.ReadKey();
        }
