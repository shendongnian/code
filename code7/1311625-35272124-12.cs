    var task = new Task(() =>
                {
                    while (true)
                    {
                        foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor)))
                        {
                            var x = Console.CursorLeft;
                            var y = Console.CursorTop;
    
                            Console.CursorLeft = 0; // set position
                            Console.CursorTop = 0; // set position
    
                            Console.ForegroundColor = c;
                            Console.WriteLine("Welcome to Tic Tac Toe!");
    
                            Console.CursorLeft = x;
                            Console.CursorTop = y;
    
                            Thread.Sleep(1000);
                        }
                    }
    
                    });
    
    do
    {
    .... rest of code
