    private async void Application_Startup(object sender, StartupEventArgs e)
    {
            var updater = new Updater();
            await updater.CheckForUpdatesAsync(...);
    }
    // ...
    class Updater
    {
        static readonly SemanticVersion ZeroVersion = new SemanticVersion(0, 0, 0, 0);
        public async Task CheckForUpdatesAsync(string squirrelUrl)
        {
            var updateProgress = new Progress<int>();
            IProgress<int> progress = updateProgress;
            //Create a splash screen that binds to progress and show it
            var splash = new UpdateSplash(updateProgress);
            splash.Show();
            using (var updateManager = new UpdateManager(squirrelUrl))
            {
                var updateInfo = await updateManager.CheckForUpdate(progress: progress.Report);
                //Get the current and future versions. If missing, replace them with version Zero
                var currentVersion = updateInfo.CurrentlyInstalledVersion?.Version ?? ZeroVersion;
                var futureVersion = updateInfo.FutureReleaseEntry?.Version ?? ZeroVersion;
                //Is there a newer version?
                if (currentVersion < futureVersion)
                {
                    await updateManager.UpdateApp(progress.Report);
                    Restart();
                }
            }
            splash.Hide();
        }
        private void Restart()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
        
