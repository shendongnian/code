    static class Program
    {
        public static DateTime Start { get; private set; }
        [STAThread]
        static void Main()
        {
            Start = DateTime.Now;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
