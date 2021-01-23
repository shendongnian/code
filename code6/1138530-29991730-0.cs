    static class Program
    {
        public static bool KeepRepeating = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            do 
            {
                Application.Run(new Form1());
            } while (KeepRepeating);
        }
    }
