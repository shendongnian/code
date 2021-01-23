        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!System.Diagnostics.Debugger.IsAttached) {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
                AppDomain.CurrentDomain.UnhandledException += LogException;
            }
            Application.Run(new Form1());
        }
        private static void LogException(object sender, UnhandledExceptionEventArgs e) {
            string errordir = Path.Combine(Application.StartupPath, "errorlog");
            string errorlog = Path.Combine(errordir, DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + ".txt");
            if (!Directory.Exists(errordir))
                Directory.CreateDirectory(errordir);
            File.WriteAllText(errorlog, e.ToString());
            AppDomain.CurrentDomain.UnhandledException -= LogException;
            MessageBox.Show("Error details recorded in " + errorlog, "Unexpected error");
            Environment.Exit(1);
        }
