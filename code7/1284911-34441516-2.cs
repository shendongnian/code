    public class MyLogger
    {
        public static void debug(string message)
        {
            var logDebug = new MyLoggerImpl();
            logDebug.debug(message);
        }
    }
