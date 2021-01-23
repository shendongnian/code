    [STAThread]
    static int Main(string[] args)
    {
        if (args != null && args.Any())
        {
            AttachConsole(-1);
            // Handle and do whatever with command line args.
            // Treat this executable as a CLI app...
        }
        else
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
