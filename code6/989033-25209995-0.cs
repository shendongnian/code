    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
          if (args[0]== "-ui")
          {
             System.Windows.Forms.Application.EnableVisualStyles();
             System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
             System.Windows.Forms.Application.Run(new MyFormWork());
          }
          else if (args[0] == "-console")
          {
             Helper.AllocConsole();
             DoYourConsoleWork();
             Helper.FreeConsole();
          }
    }
        public static class Helper
        {
            [DllImport("kernel32.dll")]
            public static extern Boolean AllocConsole();
            [DllImport("kernel32.dll")]
            public static extern Boolean FreeConsole();
        }
