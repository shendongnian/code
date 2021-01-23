                while (true)
                {
                    foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor)))
                    {
                        Console.ForegroundColor = c;
                        Console.WriteLine("Welcome to Tic Tac Toe!");
                        Console.Clear();
                    }
                }
   
