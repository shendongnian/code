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
                }
                else
                {
                    Console.WriteLine("User input is: {0}", userInput.GetType());
                    Console.WriteLine("User input is: {0}", userInput);
                }
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();                
            }
        }
    }
