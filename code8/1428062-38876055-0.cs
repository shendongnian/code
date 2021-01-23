    using System;
    using NLog;
    namespace ConsoleApplication1
    {
        class Program
        {
            private static Logger log = EventLogger.CreateLogger();
            static void Main(string[] args)
            {
                EventLogger.GenerateLog(log, "1", LogLevel.Debug, "Default", null);
                log = EventLogger.CreateLogger(@"C:\Temp\NLog\New\");
                LogManager.ReconfigExistingLoggers();
                EventLogger.GenerateLog(log, "2", LogLevel.Debug, "New", null);
                Class1.DoSomething();
                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
             }
        }
    }
