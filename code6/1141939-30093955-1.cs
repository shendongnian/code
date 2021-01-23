    namespace log4net.Core
    {
        public class Log4NetExtensions 
        {    
             public static void ErrorFormatEx(this ILog logger, string format, Exception exception, params object[] args) 
             {
                   logger.Error(string.Format(format, args), exception);
             }
        }
    }
