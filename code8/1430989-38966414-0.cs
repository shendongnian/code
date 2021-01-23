     namespace ConsoleApplication1
    {
        class Program
    {
         static void Main(string[] args)
        {
            Game rps = new Game();
            rps.printHeader();
            rps.userSettings();
            rps.gameStart();
        }
    }
