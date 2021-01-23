     using fluent.objclass;
     using FluentNHibernate.Cfg;
     using FluentNHibernate.Cfg.Db;
     using NHibernate;
     using NHibernate.Tool.hbm2ddl;
     using System.Collections.Generic;
     using System.Linq;
     using System.Reflection;
     using System.Text;
     using System.Threading.Tasks;
       namespace fluent
       {
       public class NHibernateHelper
       {
        private static ISessionFactory _sessionFactory;
        private static readonly object factorylock = new object();
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }
        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(@"Server=ARK\DARKAGE;Database=PNH;Trusted_Connection=True;").ShowSql()
                )
                .Mappings(m =>
                          m.FluentMappings
                                .AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
        public static ISession OpenSession()
        {
                    return SessionFactory.OpenSession();
        }
      }
 
    }
 
