    namespace Company.Product
    {
        using System.Text;
        using log4net;
        using log4net.Appender;
        using log4net.Core;
        using log4net.Layout;
        using log4net.Repository.Hierarchy;
        public static class LogHelper
        {
            static LogHelper()
            {
                var hierarchy = (Hierarchy)LogManager.GetRepository();
                hierarchy.Root.Level = Level.All;
                hierarchy.Configured = true;
            }
            public static ILog GetLoggerRollingFileAppender(string logName, string fileName)
            {
                var log = LogManager.Exists(logName);
                if (log != null) return log;
                var appenderName = $"{logName}Appender";
                log = LogManager.GetLogger(logName);
                ((Logger)log.Logger).AddAppender(GetRollingFileAppender(appenderName, fileName));
                return log;
            }
            public static RollingFileAppender GetRollingFileAppender(string appenderName, string fileName)
            {
                var layout = new PatternLayout { ConversionPattern = "%date{dd.MM.yyyy HH:mm:ss.fff}  [%-5level]  %message%newline" };
                layout.ActivateOptions();
                var appender = new RollingFileAppender
                {
                    Name = appenderName,
                    File = fileName,
                    AppendToFile = true,
                    RollingStyle = RollingFileAppender.RollingMode.Size,
                    MaxSizeRollBackups = 2,
                    MaximumFileSize = "500KB",
                    Layout = layout,
                    ImmediateFlush = true,
                    LockingModel = new FileAppender.MinimalLock(),
                    Encoding = Encoding.UTF8,
                };
                appender.ActivateOptions();
                return appender;
            }
        }
    }
