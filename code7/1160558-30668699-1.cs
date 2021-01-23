    protected override void OnStartup(StartupEventArgs e)
    {
        // Decide which window to show here
        // Add bounds checks etc. 
        if (e.Args[0] == "-s")
        {
            var window = new ServerPage();
            window.Show();
        }
        else
        {
            var window = new ClientPage();
            window.Show();
        }
    
        Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        base.OnStartup(e);
    }
