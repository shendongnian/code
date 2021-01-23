    public static class NlogExtensions
    {
        public static void Trace(this Logger logger, string format, Func<string> func)
        {
            if (logger.IsTraceEnabled)
            {
                logger.Trace(format, func());
            }
        }
    }
