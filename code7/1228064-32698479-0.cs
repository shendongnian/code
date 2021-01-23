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
            Application.Run(new MyContext());
        }
    }
    public class MyContext : ApplicationContext
    {
        public MyContext()
        {
            // Open your Forms...
            for(int i = 1; i <= 5; i++)
            {
                Form frm = new Form();
                frm.Text = "Form #" + i.ToString();
                frm.FormClosed += Frm_FormClosed;
                frm.Show(); 
            }
        }
        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
