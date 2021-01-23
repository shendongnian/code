    public class SessionProvider
    {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;
        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }
        public SessionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }
        private ISessionFactory CreateSessionFactory()
        {
           return Fluently.Configure()
                        .Database(SQLiteConfiguration.Standard.ConnectionString(_connectionString)
                        .Driver<ProfiledSQLiteClientDriver>)
                        .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                        .ExposeConfiguration(cfg => cfg.Properties.Add("use_proxy_validator", "false"))
                        .BuildSessionFactory();
        }
    }
