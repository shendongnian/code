    class UtilsConsole
    {
            public static bool Confirm(string title)
            {
                ConsoleKey response;
                do
                {
                    Console.Write($"{ title } [y/n] ");
                    response = Console.ReadKey(false).Key;  
                    if (response != ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                    }
                } while (response != ConsoleKey.Y && response != ConsoleKey.N);
                
                return (response == ConsoleKey.Y);
            }
    }
