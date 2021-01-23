using System;
using System.Reflection;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Core;
using log4net.Appender;
using log4net.Layout;
// ReSharper disable once CheckNamespace
namespace EasiPos.EasiLog
{
    public class Log
    {
        private static ILog _log;
        public static void Initialise(string logName, string logFile)
        {
            var hierarchy = (Hierarchy)LogManager.CreateRepository(logName);
            var patternLayout = new PatternLayout {ConversionPattern = "%date %-5level - %message%newline%exception"};
            patternLayout.ActivateOptions();
            var rollingFileAppender = new RollingFileAppender
            {
                AppendToFile = true,
                Name = logName,
                File = logFile,
                Layout = patternLayout,
                MaxSizeRollBackups = 10,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                StaticLogFileName = true
            };
            rollingFileAppender.ActivateOptions();
            hierarchy.Root.AddAppender(rollingFileAppender);
            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;
            _log = LogManager.GetLogger(logName, logName);
        }
        public static void Info(string message)
        {
            _log.Info(message);
        }
        public static void Debug(string message)
        {
            _log.Debug(message);
        }
        public static void Error(string message)
        {
            _log.Error(message);
        }
        public static void Error(Exception exception)
        {
            _log.Error(exception.Message, exception);
        }
        public static void Error(string message, Exception exception)
        {
            _log.Error(message, exception);
        }
    }
}
