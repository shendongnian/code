    var loggerRepo = LogManager.GetRepository();
    //TODO: One problem with this approach is that it will query all the appenders and configure the connection string for every call to LogInfo()
    if (loggerRepo != null) {
    var appender = loggerRepo.GetAppenders().OfType < AdoNetAppender > ().First(a => a.Name == "YourAppenderName");
    //TODO: Detemine the connection string based on the user
    appender.ConnectionString = ConfigurationManager.ConnectionStrings[""].ConnectionString;
    appender.ActivateOptions();
    }
    _log.Info("LogSOmeth9ng");
