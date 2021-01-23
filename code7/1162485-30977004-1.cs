      static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(args!=null && args.Length>0)
            Application.Run(new Scanner(args));
            else
                Application.Run(new Scanner(args));
        }
    }
