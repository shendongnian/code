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
            SomeLoginForm Login = new SomeLoginForm();
            Login.ShowDialog();
            if (!Login.HasPassedAuthorization)
            {
                MessageBox.Show("Sorry you failed to pass the test! I'm kicking you out now!");
                Application.Exit(); // or do a "return;"
            }
    
            Application.Run(new Form1());
        }
    }
    
    
    static class SomeLoginForm()
    {
            internal bool HasPassedAuthorization;
    
    }
