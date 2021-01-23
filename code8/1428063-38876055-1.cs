    using NLog;
    namespace ConsoleApplication1
    {
        public static class Class1
        {
            private static Logger log = EventLogger.CreateLogger();
    
            public static void DoSomething()
            {
                EventLogger.GenerateLog(log, "3", LogLevel.Debug, "Class1.DoSomething", null);
            }
        }
    }
