        public static void Main(string[] args)
        {
            Console.Write("Enter a random number? ");
            string userInput = Console.ReadLine();
            Console.WriteLine(" You entered: " + userInput);
            try
            {
                int input = int.Parse(userInput);
                PrintMessage(input);
            }
            catch (Exception)
            {
                Console.WriteLine(" Error message: Your input is not a number");
            }
        }
        private static void PrintMessage(int input)
        {
            if (input < 0)
            {
                Console.WriteLine(" Error message: Out of range: Enter a number between 0 and 200");
            }
            else if (input > 100)
            {
                Console.WriteLine(" You are above average");
            }
            else if (input == 100)
            {
                Console.WriteLine(" You are average");
            }
            else
            {
                Console.WriteLine(" Sorry but you are below average");
            }
        }
 
