    public class Program
    {
        private class MyAppContext : ApplicationContext
        {
            public MyAppContext()
                : base(new Form())
            {
                //Exit delegate
                Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
                MainForm.Show();
            }
            private void OnApplicationExit(object sender, EventArgs e)
            {
                //Cleanup code...
            }
        }
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyAppContext());
        }
    }
