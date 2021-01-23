            Console.WriteLine("Name a color");
            string color = Console.ReadLine();
            ConsoleColor consoleColor = ConsoleColor.White;
            try
            {
                consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
            }
            catch (Exception)
            {
                //Invalid color
            }
            Console.ForegroundColor = consoleColor ;
