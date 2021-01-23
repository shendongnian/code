    static class Program
    {
        static SplashForm SplashForm;
        static MainForm MainForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Show SplashForm
            SplashForm = new SplashForm();
            if (SplashForm != null)
            {
                Thread splashThread = new Thread(new ThreadStart(() => { Application.Run(SplashForm); }));
                splashThread.SetApartmentState(ApartmentState.STA);
                splashThread.Start();
            }
            //Create and Show MainForm
            MainForm = new MainForm();
            MainForm.LoadCompleted += MainForm_LoadCompleted;
            Application.Run(MainForm);
        }
        private static void MainForm_LoadCompleted(object sender, EventArgs e)
        {
            if (SplashForm == null || SplashForm.Disposing || SplashForm.IsDisposed)
                return;
            SplashForm.Invoke(new Action(() => { SplashForm.Close(); }));
            SplashForm.Dispose();
            SplashForm = null;
            MainForm.Activate();
        }
    }
