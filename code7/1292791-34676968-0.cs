    if (logLevel == 1)
    {
        // assuming appender name is DebugAppender and it is a FileAppender
        var appender = log4net.LogManager.GetRepository()
                                            .GetAppenders()
                                            .OfType<FileAppender>()
                                            .SingleOrDefault(a => a.Name == "DebugAppender");
        if (appender != null)
        {
            // Disable the appender
            appender.Threshold = Level.Off;
            appender.ActivateOptions();
        }
    }
