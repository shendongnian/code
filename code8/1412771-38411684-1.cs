            DateTime lastPressedTime = DateTime.MinValue;
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (DateTime.Now > lastPressedTime.AddSeconds(.5))
                {
                    switch (key)
                    {
                        case ConsoleKey.Enter:
                        //code
                        case ConsoleKey.UpArrow:
                        //code
                        case ConsoleKey.DownArrow:
                        //code
                        case ConsoleKey.Escape:
                        //code
                    }
                }
                lastPressedTime = DateTime.Now;
            }
