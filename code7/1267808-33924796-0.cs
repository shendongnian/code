    public class Program
    {
        public static void Main(string[] args)
        {
            const char toWrite = '*'; // Character to write on-screen.
            int x = 0, y = 0; // Contains current cursor position.
            Write(toWrite); // Write the character on the default location (0,0).
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;
                    switch (command)
                    {
                        case ConsoleKey.DownArrow:
                            y++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (y > 0)
                            {
                                y--;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (x > 0)
                            {
                                x--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            x++;
                            break;
                    }
                    Write(toWrite, x, y);
                }
            }
        }
        public static void Write(char toWrite, int x = 0, int y = 0)
        {
            try
            {
                if (x >= 0 && y >= 0) // 0-based
                {
                    Console.Clear();
                    Console.SetCursorPosition(x, y);
                    Console.Write(toWrite);
                }
            }
            catch (Exception)
            {
            }
        }
    }
