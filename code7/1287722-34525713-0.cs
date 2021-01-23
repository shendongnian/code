        public static ConsoleColor ReadColor()
        {
            string tmp = tmp = Console.ReadLine().Trim().ToLower();
            switch (tmp)
            {
                case "red": return ConsoleColor.Red;
                case "green": return ConsoleColor.Green;
                case "black": return ConsoleColor.Black;
                default:
                    throw new InvalidOperationException("Invalid input - " + tmp);
            }
        }
