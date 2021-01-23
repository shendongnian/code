    using System;
    using NLog;
    using NLog.Config;
    using NLog.Targets;
    namespace LogEngine
    {
        /// <summary>
        ///     Create an instance of NLog for use on a per class level. 
        /// </summary>
        internal sealed class EventLog
        {
            #region Constructors
            static EventLog()
            {
            }
            private EventLog()
            {
                this.CreateLogger();
            }
            #endregion Constructors
            #region Singleton Objects
            internal static EventLog logger { get { return _logger; } }
            private static readonly EventLog _logger = new EventLog();
            #endregion Singleton Objects
            #region Private Fields
            private static Logger _log;
            #endregion Private Fields
            #region Internal Methods
            /// <summary>
            ///     Generates the NLog.Logger object that will control logging facilities in this program. 
            /// </summary>
            internal void CreateLogger(string baseDir = @"${basedir}\")
            {
                // Setup log configuration object and new file and screen output targets.
                var config = new LoggingConfiguration();
                var screenTarget = new ConsoleTarget();
                config.AddTarget("screen", screenTarget);
                var fileTarget = new FileTarget();
                config.AddTarget("file", fileTarget);
                screenTarget.Layout = @"${newline}${message}";
                var MinScreenOutput = new LoggingRule("*", LogLevel.Fatal, screenTarget);
                config.LoggingRules.Add(MinScreenOutput);
                // Set the properties for the file output target.
                fileTarget.FileName = baseDir + @"${appdomain:format={1\}} logs\${shortdate}.log";
                fileTarget.Layout = @"${longdate} ${pad:padcharacter=~:padding=29:inner= ${level:uppercase=true}}"
                                    + @" ${pad:padcharacter=~:padding=30:inner= Event ID\: ${event-properties:item=EventCode}}"
                                    + @"${newline}${message} ${when:when=level == 'Error':inner=${newline}Class / Method\:"
                                    + @"${pad:padding=9:inner=}${callsite:fileName=true:includeSourcePath=false:skipFrames=1}"
                                    + @"${newline}Exception\:${pad:padding=14:inner=}${exception}}"
                                    + @"${when:when=level == 'Fatal':inner=${newline}Class / Method\:"
                                    + @"${pad:padding=9:inner=}${callsite:fileName=true:includeSourcePath=false:skipFrames=1}"
                                    + @"${newline}Exception\:${pad:padding=14:inner=}${exception}}${newline}";
                // Define what sort of events to send to the file output target.
                var MinOutputDebug = new LoggingRule("*", LogLevel.Debug, fileTarget);
                config.LoggingRules.Add(MinOutputDebug);
                // Set the configuration for the LogManager
                LogManager.Configuration = config;
                // Get the working instance of the logger.
                _log = LogManager.GetLogger("LogEngine");
            }
            /// <summary>
            ///     Passes one log entry to the destination logger and associated exception information. 
            /// </summary>
            /// <remarks>
            ///     Use this form of the method when <see cref="NLog.LogLevel.Error" /> or
            ///     <see cref="NLog.LogLevel.Fatal" /> is used.
            /// </remarks>
            /// <param name="caller">
            ///     <see cref="System.String" /> holding information about the calling method. 
            /// </param>
            /// <param name="eventId">
            ///     Four character unique event ID as <see cref="System.String" />. 
            /// </param>
            /// <param name="level">
            ///     The <see cref="NLog.LogLevel" /> value. 
            /// </param>
            /// <param name="message">
            ///     The message to save to the log file as <see cref="System.String" />. 
            /// </param>
            /// <param name="ex">
            ///     If this is an error log event, pass it as an <see cref="System.Exception" /> object. 
            /// </param>
            internal void GenerateLog(string eventId, LogLevel level, string message, Exception ex)
            {
                // Values used for all events.
                LogEventInfo logEvent = new LogEventInfo();
                logEvent.Properties["EventCode"] = eventId;
                logEvent.Level = level;
                logEvent.Message = message;
                logEvent.Exception = ex;
                // Actually write the log entry.
                _log.Log(logEvent);
                if (level.Equals(LogLevel.Error) || level.Equals(LogLevel.Fatal))
                    Environment.Exit(Convert.ToInt32(eventId));
            }
            /// <summary>
            ///     Passes one log entry to the destination logger. 
            /// </summary>
            /// <remarks>
            ///     Use this form of the method when <see cref="NLog.LogLevel.Warn" /> or
            ///     <see cref="NLog.LogLevel.Info" /> is used.
            /// </remarks>
            /// <param name="caller">
            ///     <see cref="System.String" /> holding information about the calling method. 
            /// </param>
            /// <param name="eventId">
            ///     Four character unique event ID as <see cref="System.String" />. 
            /// </param>
            /// <param name="level">
            ///     The <see cref="NLog.LogLevel" /> value. 
            /// </param>
            /// <param name="message">
            ///     The message to save to the log file as <see cref="System.String" />. 
            /// </param>
            internal void GenerateLog(string eventId, LogLevel level, string message)
            {
                // Values used for all events.
                LogEventInfo logEvent = new LogEventInfo();
                logEvent.Properties["EventCode"] = eventId;
                logEvent.Level = level;
                logEvent.Message = message;
                // Actually write the log entry.
                _log.Log(logEvent);
            }
            #endregion Internal Methods
        }
    }
