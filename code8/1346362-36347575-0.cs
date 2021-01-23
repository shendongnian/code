    private static void Main(string[] args)
    {
        // If there are no args run default (Form1):
        if (args.Length < 0)
        {
            Application.Run(new Form1());
            return;
        }
        // If there are args check them
        foreach(var a in args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            switch(a)
            {
                case "aProject": 
                    Application.Run(new Project());
                    break;
                case "aDifferentProject":
                    Application.Run(new ADifferentProject());
                    break;
            }
        }
    }
