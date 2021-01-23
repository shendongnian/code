    static void Main(string[] args)
        {
            string input;
            Console.WriteLine("Type in some text: ");
            input = Console.ReadLine();
            while(input.Any(char.IsDigit))
            {
                Console.WriteLine("Please type in some text without numbers");
                input = Console.ReadLine();
            }
        }
