    static void Main(string[] args)
    {
      while (true)
      {
        Console.WriteLine("Press Key R,G,B,D,C,M to change Console Color. Press E to Exit");
        switch (Console.ReadKey(true).Key)
        {
          case ConsoleKey.R:
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            break;
          case ConsoleKey.G:
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            break;
          case ConsoleKey.B:
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            break;
          case ConsoleKey.D:
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            break;
          case ConsoleKey.C:
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            break;
          case ConsoleKey.M:
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            break;
          case ConsoleKey.E:
            return;
          default:
            Console.WriteLine("You didn't press Key R,G,B,D,C,M.");
            break;
        }
        Console.WriteLine("Press Key R,G,B,D,C,M to change Console Color");
      }
    }
