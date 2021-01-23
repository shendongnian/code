    [Binding]
    public class DataHooks
    {
        private readonly IObjectContainer objectContainer;
        private static ISessionFactory sessionFactory;
        public DataHooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }
        [BeforeTestRun]
        public static void SetupNhibernateSessionFactory()
        {
            sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("SqlServerDataTesting")))
                .Mappings(cfg =>
                    cfg.FluentMappings.AddFromAssemblyOf<HostMap>()
                )
                .BuildSessionFactory();
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            objectContainer.RegisterInstanceAs<ISessionFactory>(sessionFactory);
        }
    }
