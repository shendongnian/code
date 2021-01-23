        /// <summary>
        /// Log Class For nLog
        /// </summary>
        internal static class Log
        {
            public static Logger Instance { get; private set; }
            static Log()
            {
                LogManager.ReconfigExistingLoggers();
    
                Instance = LogManager.GetCurrentClassLogger();
            }
        }
    
        
        /// <summary>
        /// custom Logger Class gor Logger
        /// </summary>
        public static class Loggers
        {
            /// <summary>
            /// Static Mathod For Info Message
            /// </summary>
            /// <param name="Message"></param>
            public static void Info(string Message)
            {
                Log.Instance.Info(Message);
            }
            /// <summary>
            /// Static Method For Error Logger
            /// </summary>
            /// <param name="Ex"></param>
            public static void Error(Exception Ex)
            {
                Log.Instance.Error(Ex);
            }
    
            /// <summary>
            /// Static Method For Debug
            /// </summary>
            /// <param name="Message"></param>
            public static void Debug(string Message)
            {
                Log.Instance.Debug(Message);
            }
        }
