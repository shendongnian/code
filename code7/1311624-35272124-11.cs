    Console.WriteLine("Some text"); // this text will stay when tesxt "Welcome to Tic Tac Toe!" will by blinking
     while (true)
        {
            foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor)))
            {
                Console.CursorLeft = 4; // set position
                Console.CursorTop = 6; // set position
                Console.ForegroundColor = c;
                Console.WriteLine("Welcome to Tic Tac Toe!");
              
            }
        }
