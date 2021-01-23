    static class Program
    {
        private static Form1 _mainForm = new Form1();
        public static Form1 MainForm { get { return _mainForm; } }
        [MTAThread]
        static void Main()
        {
            // blablabla
            // do not call this until you want to show main window
            MainForm.ShowDialog();
        }
    }
