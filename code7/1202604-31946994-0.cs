    do
    {
        ConsoleKeyInfo info = Console.ReadKey();
    
            if (info.Key == ConsoleKey.F)
            {
                System.Threading.Thread.Sleep(500);
                {
                    hunger = hunger + 10;
                    Console.WriteLine("Food: {0:0.0}".PadRight(15), hunger);
                    Console.WriteLine("Water: {0:0.0}".PadRight(70), thirst);
                }
            }
            if (info.Key == ConsoleKey.D)
            {
                System.Threading.Thread.Sleep(500);
                {
                    thirst = thirst + 10;
                    Console.WriteLine("Food: {0:0.0}".PadRight(15), hunger);
                    Console.WriteLine("Water: {0:0.0}".PadRight(70), thirst);
                }
            }
    }
    while(info.Key != ConsoleKey.Escape);
