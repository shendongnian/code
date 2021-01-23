    namespace sequence
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = Console.ReadLine();
                int userInput;
                if (!int.TryParse(input, out userInput))
                {
                    Console.WriteLine("You have entered invalid number");
                    return;
                }    
                Console.WriteLine("User input is: {0}", userInput.GetType());
                Console.WriteLine("User input is: {0}", userInput);
            }
        }
    }
