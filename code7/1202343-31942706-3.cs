        [STAThread]
        static void Main(string[] args)
        {
            if (args.Any() && args[0] == "-cli")
            {
                Console.WriteLine("Console app");
            }
            else
            {
                HideConsoleWindow();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
