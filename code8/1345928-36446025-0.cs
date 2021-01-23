    static readonly SemanticVersion ZeroVersion = new SemanticVersion(0, 0, 0, 0);
    private async void Application_Startup(object sender, StartupEventArgs e)
    {
        await CheckForUpdatesAsync();
    }
    private async Task CheckForUpdatesAsync()
    {
        string squirrelUrl = "...";
        var updateProgress = new Progress<int>();
        IProgress<int> progress = updateProgress;
        //Create a splash screen that binds to progress and show it
        var splash = new UpdateSplash(updateProgress);
        splash.Show();
        using (var updateManager = new UpdateManager(squirrelUrl))
        {
            //IProgress<int>.Report matches Action<i>
            var info = await updateManager.CheckForUpdate(progress: progress.Report);
            //Get the current and future versions. 
            //If missing, replace them with version Zero
            var currentVersion = info.CurrentlyInstalledVersion?.Version ?? ZeroVersion;
            var futureVersion = info.FutureReleaseEntry?.Version ?? ZeroVersion;
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
        Process.Start(ResourceAssembly.Location);
        Current.Shutdown();
    }
