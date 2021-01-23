    var loggerRepo = LogManager.GetRepository();
    if (loggerRepo != null) {
    var appender = loggerRepo.GetAppenders().OfType < AdoNetAppender > ().First(a => a.Name == "YourAppenderName");
    appender.ConnectionString = ConfigurationManager.ConnectionStrings[""].ConnectionString;
    appender.ActivateOptions();
    }
    _log.Info("LogSOmeth9ng");
