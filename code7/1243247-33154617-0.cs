    public static class LoggerFacadeExtensions
    {
        public static void Debug(this ILoggerFacade logger, string message)
        {
            logger.Log(message, Category.Debug, Priority.High);
        }
    }
