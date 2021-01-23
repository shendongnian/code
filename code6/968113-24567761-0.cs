    namespace My_Program
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static Mutex mx;
            const string singleInstance = @"MU.Mutex";
    
            [STAThread]
            static void Main(string[] args)
            {
                try
                {
                    System.Threading.Mutex.OpenExisting(singleInstance);
                    MessageBox.Show("The program is already running!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception e)
                {
                    mx = new System.Threading.Mutex(true, singleInstance);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
        }
    }
