    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // <- Here
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
