    static void Main(string[] args)
    {
      Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
      Console.CursorLeft = 0;
      Console.CursorTop = 0;
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.Write("This is the statusbar".PadRight(Console.WindowWidth, ' '));
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.White;
      int line = 1;
      int totalLines = 1;
      while (true) {
        Thread.Sleep(100);
        if (line == Console.WindowHeight){
          // Scoll one line:
          Console.MoveBufferArea(0, 2, Console.WindowWidth, Console.WindowHeight - 2, 0, 1);
          line--;
        }
        Console.CursorLeft = 0;
        Console.CursorTop = line;
        Console.Write(string.Format("This is line {0}", totalLines));
        totalLines++;
        line++;
      }
    }
