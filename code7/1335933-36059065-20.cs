    public class NHibernateHelper
    {
        public static ISession OpenSession(string connectionString)
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
