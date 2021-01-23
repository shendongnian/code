    public static int enter_No_Of_Items(int min, int max)
        {
            string input = "input";
            bool ok = false;
            while (ok == false)
            {
                Console.WriteLine("Enter a number between {0} and {1}.", min, max);
                input = Console.ReadLine();
                if ((int.Parse(input) >= min) && (int.Parse(input) <= max))
                {
                    Console.WriteLine("Valid number.");
                    break;
                }
                Console.WriteLine("Invalid number.");
            }
            return int.Parse(input);
        }
        static void Main(string[] args)
        {
            int randomA = 5;
            int randomB = 9;
            int itemCount = enter_No_Of_Items(randomA, randomB);
            Console.ReadLine();
        }
