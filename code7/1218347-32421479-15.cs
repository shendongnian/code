    using System;
    using System.Threading;
    using System.Windows.Forms;
    static class Program
    {
        static Form SplashScreen;
        static Form MainForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Show Splash Form
            SplashScreen = new Form();
            var splashThread = new Thread(new ThreadStart(
                () => Application.Run(SplashScreen)));
            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();
            //Create and Show Main Form
            MainForm = new Form8();
            MainForm.Load += MainForm_LoadCompleted;
            Application.Run(MainForm);
        }
        private static void MainForm_LoadCompleted(object sender, EventArgs e)
        {
            if (SplashScreen != null && !SplashScreen.Disposing && !SplashScreen.IsDisposed)
                SplashScreen.Invoke(new Action(() => SplashScreen.Close()));
            MainForm.TopMost = true;
            MainForm.Activate();
            MainForm.TopMost = false;
        }
    }
