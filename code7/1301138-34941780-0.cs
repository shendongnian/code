    static void Main()
    {
        string[] args = Environment.GetCommandLineArgs();
        if (args.Length <= 1)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        else
        {
            switch (args[1])
            {
                case "1": Console.WriteLine("Doing #1 stuff"); break;
                case "2": Console.WriteLine("Doing #2 stuff"); break;
                case "n": Console.WriteLine("Doing #n stuff"); break;
            }
        }
    }
