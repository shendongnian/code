              while (true)
                {
                    foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor)))
                    {
                        Console.ForegroundColor = c;
                        Console.WriteLine("Welcome to Tic Tac Toe!");
                        Thread.Sleep(1000); // 1 sec. deley
                        Console.Clear();
                    }
                }
   
