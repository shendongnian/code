    private static void Main()
    {
        int restartCount = 0;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    
        var applicationCtx = new MyApplicationContext();
    
        applicationCtx.RestartRequested += (o, e) =>
        {
            restartCount++; //this is just here so my program would stop restarting
            if (restartCount > 5) Application.Exit();
    
            Application.Restart();
        };
    
        Application.Run(applicationCtx);
    }
