    public class NLogLogger : IAppLogger
    {
        private readonly NLog.Logger _logger;
    
        public NLogLogger(Type callerType)
        {
           _logger = NLog.LogManager.GetLogger(callerType.Name,callerType);
        }
    
        public void Info(string message)
        {
           _logger.Info(message);
        }
    
        public void Warn(string message)
        {
           _logger.Warn(message);
        }
        .....// and others
     }
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IAppLogger>().ToMethod(p => new NLogLogger(p.Request.Target.Member.DeclaringType));
        }
    }
