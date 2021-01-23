    public class Logger {
         private static object _lock = new object();
         private static Logger _logger = null;
         public static Instance { get {
              if ( _logger == null ) {
                 lock(_lock) {
                     if ( _logger == null ) {
                         _logger = new Logger();
                     }
                 }
              }
         }
         private Logger() {}
         public void LogMessage(string message) {
              //code to log here, 
         }
    }
