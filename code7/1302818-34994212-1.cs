       while(true)
                {
                    Console.WriteLine("Press Key R,G,B,D,C,M to change Console Color");
               
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.R)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Clear();
                    }
    
                    else if (key.Key == ConsoleKey.G)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Clear();
                    }
    
                    else if (key.Key == ConsoleKey.B)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                    }
    
                    else if (key.Key == ConsoleKey.D)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                    }
    
                    else if (key.Key == ConsoleKey.C)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Clear();
                    }
    
                    else if (key.Key == ConsoleKey.M)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Clear();
                    }
    
                    else
                    {
                        Console.WriteLine("You didn't press Key R,G,B,D,C,M.");
                    }
    
                };
