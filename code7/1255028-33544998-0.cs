    private void LogFile(string logFileName, string message, Exception ex)
    {
        log4net.ThreadContext.Properties["Version"] = "1";
        log4net.GlobalContext.Properties["LogName"] = logFileName;
        ILog logger = LogManager.GetLogger("DeIdentifyDicom");
        log4net.Config.XmlConfigurator.Configure();
        if (ex != null)
        {
            logger.Fatal(message, ex);
        }
        else
        {
            logger.Fatal(message);
        }
    }
