    static class Log
    {
        static void Debug(object message);
        static void Debug(IFormattable message);
        static void Debug(FormattableString message);
        static bool IsDebugEnabled { get; }
    }
