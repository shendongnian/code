    class Program
    {
        private static Lazy<Logger> logger = new Lazy<Logger>(() => LogManager.GetCurrentClassLogger());
        static void Main(string[] args)
        {
            //this will throw TypeInitialization with InnerException as a NLogConfigurationException because of bad config. (like invalid XML)
            logger.Value.Info("Test");
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
