    // we need command line arguments in Main method
    [STAThread]
    static void Main(string[] args)
    {
        if (args.Length > 0 && args[0] == "service")
        {
            // runs service;
            // generated bootstrap code was simplified a little
            ServiceBase.Run(new[]
            {
                new Service1()
            });
        }
        else
        {
            // runs GUI application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
