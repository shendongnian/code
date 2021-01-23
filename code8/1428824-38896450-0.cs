    public partial class App : Application
    {
        // A Splash-Window to overlay until everything is ready.
        public SplashWindow AppLauncher = new SplashWindow(); 
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppLauncher.lblText.Content = "Loading data...";
            AppLauncher.Show();
        }
    }
