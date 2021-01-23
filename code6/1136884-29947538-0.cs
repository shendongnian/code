    class Program
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();
    
        [DllImport("Kernel32")]
        public static extern void FreeConsole();
    
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "console")
            {
                AllocConsole();
    
                Console.WriteLine("Now I'm a console app!");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey(true);
    
                FreeConsole();
            }
            else
            {
                WpfApplication1.App.Main();
            }
        }
    }
