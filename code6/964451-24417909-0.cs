        public static string ReadLine()
        {
            bool done = false;
            StringBuilder sb = new StringBuilder();
            while (!done)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    done = true;
                }
                else
                {
                    sb.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
            return sb.ToString();
        }
