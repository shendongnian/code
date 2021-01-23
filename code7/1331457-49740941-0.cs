    public abstract class AwsVerboseLogsAppender : AppenderSkeleton
    {
        // ...
        protected override void Append(LoggingEvent loggingEvent)
        {
            // ...
        }
        // ...
    }
    // ...
    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
    var fileinfo = new FileInfo(path);
    XmlConfigurator.Configure(fileinfo);
    var log = LogManager.GetLogger(GetType());
    LogicalThreadContext.Properties["Test"] = "MyValue";
    log.Debug("test");
