    public class LoggerInstall : IWindsorInstaller
    {
        private const string NLogConnectionString = "NLogConnection";
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var config = new NLog.Config.LoggingConfiguration();
            container.AddFacility<LoggingFacility>(l => l.LogUsing(new OwnNLogFactory(GetYourConnectionStringMethod(NLogConnectionString))));
        }
    }
    public class OwnNLogFactory : NLogFactory  
    {
        public OwnNLogFactory(string connectionString)
        {
            foreach (var dbTarget in LogManager.Configuration.AllTargets.OfType<DatabaseTarget>().Select(aTarget => aTarget))
            {
                dbTarget.ConnectionString = connectionString;
            }
        }
    }
