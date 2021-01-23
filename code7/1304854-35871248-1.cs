    if(!LogManager.GetRepository().Configured)
    {
        XmlConfigurator.Configure();
    }
    
    if (!LogManager.GetRepository().Configured)
    {
        var logMsg = new StringBuilder();
        logMsg.AppendLine("Failed to initialize log4net");
        foreach(var msg in LogManager.GetRepository().ConfigurationMessages)
        {
            logMsg.AppendLine(msg.ToString());
        }
        // ....do something with the message, raise
        // an evt to UI, log to OS Event logger, etc....
    }
