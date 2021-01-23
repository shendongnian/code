    public static class Program
    {
        private static void Main()
        {
            var kernel = new StandardKernel();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(kernel.Get<Form1>());
        }
    }
