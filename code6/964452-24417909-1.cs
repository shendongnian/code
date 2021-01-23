        public static string ReadLine()
        {
            bool done = false;
            StringBuilder sb = new StringBuilder();
            while (!done)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch(key.Key)
                {
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                    case ConsoleKey.Backspace:
                        sb.Length -= 1;
                        Console.Write(key.KeyChar);
                        Console.Write(" ");
                        Console.Write(key.KeyChar);
                        break;
                    default:
                        sb.Append(key.KeyChar);
                        Console.Write(key.KeyChar);
                        break;
                }
            }
            }
            return sb.ToString();
        }
