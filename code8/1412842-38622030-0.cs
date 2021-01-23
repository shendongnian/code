    using log4net;
    using log4net.Config;
    using log4net.Repository.Hierarchy;
    using log4net.Core;
    using log4net.Appender;
    using log4net.Layout;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace MyProgram
    {
        [TestClass]
        public class AssemblyInitializer
        {
    
            private static ILog log = null;
    
            [AssemblyInitialize]
            public static void Configure(TestContext Context)
            {
                Debug.WriteLine("Starting log4net setup and configuration");
    
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
                hierarchy.Root.RemoveAllAppenders();
    
                PatternLayout patternLayout = new PatternLayout();
                patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
                patternLayout.ActivateOptions();
    
                FileAppender fileAppender = new FileAppender();
                fileAppender.Name = "Integration Test FileAppender";
                fileAppender.File = @"Logs\IntegrationTest.log";
                fileAppender.AppendToFile = false;
                fileAppender.Layout = patternLayout;
                fileAppender.ActivateOptions();
                hierarchy.Root.AddAppender(fileAppender);
    
                ConsoleAppender consoleAppender = new ConsoleAppender();
                consoleAppender.Name = "Integration Test ConsoleAppender";
                consoleAppender.Target = Console.Out.ToString();
                consoleAppender.ActivateOptions();
                consoleAppender.Layout = patternLayout;
                hierarchy.Root.AddAppender(consoleAppender);
    
                hierarchy.Root.Level = Level.Debug;
                hierarchy.Configured = true;
    
                log = LogManager.GetLogger(typeof(AssemblyInitializer));
                log.Debug("log4net initialized for Integration Test");
    
                Debug.WriteLine("Completed log4net setup and configuration");
    
            }
        }
    }
