    if (Environment.UserInteractive)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new ServiceGUI(new MyService()));
    }
    else
    {
        ServiceBase.Run(new ServiceBase[] { new MyService() });
    }
