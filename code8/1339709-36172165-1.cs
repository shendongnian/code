    using System;
    using NLog;
    namespace Tvinio.Core.Logging.NLog
    {
        public class NLogger : ILogger
        {
            private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
            public void Trace(string message)
            {
                Logger.Trace(message);
            }
            public void Trace(string format, params object[] args)
            {
                Logger.Trace(format, args);
            }
            public void Info(string message)
            {
                Logger.Info(message);
            }
            public void Error(string message)
            {
                Logger.Error(message);
            }
            public void Error(string message, Exception exception)
            {
                Logger.Error(exception, message);
            }
            public void Error(Exception exception)
            {
                Logger.Error(exception);
            }
        }
    }
