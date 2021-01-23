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
                //Use the global reference for form1
                clsGlobal.frm1 = new Form1();
                Application.Run(clsGlobal.frm1);
            }
        }
