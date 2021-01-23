    namespace YorNameSpace
    {
    public static class Program
    {
        public static DialogResult result;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var loginForm = new loading())
             result=loginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // login was successful
                Application.Run(new Main());
            }
        }
    }
    }
