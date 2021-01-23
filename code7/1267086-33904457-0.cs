    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
          int x = 1;
          int y = 1;
          while(true)
          {
             PrintToScreendynamic(x, y, "helo");
             y++;
          }
        }
        static void PrintToScreendynamic(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
