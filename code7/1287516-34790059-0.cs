    public class SessionFactoryHolder
    {
        private static ISessionFactory sessionFactory;
        public static void SetupNhibernateSessionFactory()
        {
            sessionFactory = Fluently.Configure()
                                     .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("SqlServerDataTesting")))
                                     .Mappings(cfg => cfg.FluentMappings.AddFromAssemblyOf<HostMap>()            )
            .BuildSessionFactory();
        }
        public ISessionFactory SessionFactory
        {
            get { return sessionFactory; }
        }
    }
    [Binding]
    public class Binding
    {
         [BeforeTestRun]
         public static void SetupNhibernateSessionFactory()
         {
             SessionFactoryHolder.SetupNhibernateSessionFactory();
         }
    }
