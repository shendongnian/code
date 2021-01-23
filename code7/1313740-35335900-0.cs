    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginForm = new LoginForm();
            DialogResult res = loginForm.ShowDialog();
            if (res != DialogResult.OK)
                return;
            if (loginForm.MyEnumCode == 1)
            { //AdminForm
                Application.Run(new AdminForm());
            }
            else if (loginForm.MyEnumCode == 2)
            { //PlayerForm
                Application.Run(new PlayerForm());
            }
        }
    }
