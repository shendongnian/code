    private Task updateTask;
    protected override async void OnStartup(StartupEventArgs e)
    {
        updateTask = StartupAsync(e);
    }
    private Task StartupAsync(StartupEventArgs e)
    {
        this.Dispatcher.UnhandledException += Dispatcher_UnhandledException;
        for (int i = 0; i < e.Args.Length; i++)
        {
            if (e.Args[i].ToLower() == "/ForceInstall".ToLower() || e.Args[i].ToLower() == "-ForceInstall".ToLower() || e.Args[i].ToLower() == "-F".ToLower() || e.Args[i].ToLower() == "/F".ToLower())
            {
                ApplicationConstants.Instance.ForceInstall = true;
            }
        }
        base.OnStartup(e);
        var restartApp = false;
        using (var mgr = new UpdateManager(@"http://wintst01:8282/unidealoffice/starter"))
        {
            var re = await mgr.UpdateApp(DownloadProgress);
            if (re == null)
            {
                Debug.WriteLine("NULL");
            }
            else
            {
                MessageBox.Show($"Applicatie is bijgewerkt en dient herstart te worden\nNieuwe versie: {re.Version}", "Update");
                restartApp = true;
            }
        }
        if (restartApp)
        {
            UpdateManager.RestartApp();
        }
    }
