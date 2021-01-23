    public static class SessionFactory
    {
        private static ISessionFactory _factory;
    
        public static ISession OpenSession()
        {
            return _factory.OpenSession();
        }
    
        public static void Init(string connectionString)
        {
            _factory = BuildSessionFactory(connectionString);
        }
    
        private static ISessionFactory BuildSessionFactory(string connectionString)
        {
            ISessionFactory sessionFactory = Fluently
                .Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL81
                    .ConnectionString(c => c.Is(connectionString))
                    .ShowSql())
    
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<GenreMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
    
            return sessionFactory.OpenSession();
        }
    }
