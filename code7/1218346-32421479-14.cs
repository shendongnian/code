    using System;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            var app = new MyApplication();
            app.Run(Environment.GetCommandLineArgs());
        }
    }
    public class MyApplication : WindowsFormsApplicationBase
    {
        protected override void OnCreateMainForm()
        {
            MainForm = new YourMainForm();
        }
        protected override void OnCreateSplashScreen()
        {
            SplashScreen = new YourSplashForm();
        }
    }
