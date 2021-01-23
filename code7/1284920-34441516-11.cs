    public class MyLogger
    {
        public static void debug(string message)
        {
            var log = new MyLoggerImpl();
            log.debug(message);
        }
    }
