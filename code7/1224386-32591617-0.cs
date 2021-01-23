    class Program
    {
        static void Main(string[] args)
        {
            bool knownKeyPressed = false;
            do
            {
                Console.WriteLine("Press 1 or 2 please...");
                ConsoleKeyInfo keyReaded = Console.ReadKey();
                switch (keyReaded.Key)
                {
                    case ConsoleKey.D1: //Number 1 Key
                        Console.WriteLine("Number 1 was pressed");
                        Console.WriteLine("Question number 1");
                        knownKeyPressed = true;
                        break;
                    case ConsoleKey.D2: //Number 2 Key
                        Console.WriteLine("Number 2 was pressed");
                        Console.WriteLine("Question number 2");
                        knownKeyPressed = true;
                        break;
                    default: //Not known key pressed
                        Console.WriteLine("Wrong key, please try again.");
                        knownKeyPressed = false;
                        break;
                }
            } while(!knownKeyPressed);
            Console.WriteLine("Bye, bye");
            Console.ReadLine();
        }
    }
