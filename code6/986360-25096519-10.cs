    static class Program
    {
        public static Form1 MainForm;
        [STAThread]
        public static int Main()
        {
            MainForm = new Form1(); // THIS IS IMPORTANT
            Application.Run(MainForm);
        }
    }
