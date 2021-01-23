        while (true)
            {
                var input = Console.ReadKey(true);
                Console.WriteLine(input.Key.ToString() + " pressed");
                if (input.Key == ConsoleKey.F10)
                {
                    Console.WriteLine("Breaking loop.");
                    break;
                }
            }
