    protected override void OnStartup(StartupEventArgs e)
    {
        if (e.Args.Count() > 0)
        {
            var a = File.Exists(e.Args[0]);
            var path = Path.GetFullPath(e.Args[0]);
            MainICPUI.workingDirectory = Directory.GetCurrentDirectory();
            MainICPUI.fileOpen = e.Args[0];
        }
        base.OnStartup(e);
    }
