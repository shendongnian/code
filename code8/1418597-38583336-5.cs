    Console.TreatControlCAsInput = true;
            while (true)
            {
                var k = Console.ReadKey(true);
                if ((k.Modifiers & ConsoleModifiers.Control) != 0)
                {
                    if ((k.Key & ConsoleKey.C) != 0)
                    {
                        break;
                    }
                }
                Thread.Sleep(100);
                Console.WriteLine("..");
            }
