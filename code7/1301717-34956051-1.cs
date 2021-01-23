    using log4net;
    ...
     static void Main(string[] args)
            {
                log4net.Config.XmlConfigurator.Configure(); // Missing!!?
    
                ILog log = LogManager.GetLogger("MyLogger");
                log.Info("message");
