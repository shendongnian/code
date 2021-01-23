     static void Main(string[] args)
        {
            var input = 0;
            Console.Write("Enter a number between 1 and 100: ");
            while (true)
            {
              if (int.TryParse(Console.ReadLine(), out input) && (input < 0 || input > 100))
                {
                    Console.Write("The value must be a number greater than 0, but less than 100 please try again: ");
                }
                else
                {
                    Console.WriteLine("Thank you for the correct input");
                    break;
                }
            }
            Console.ReadKey();        
        }
