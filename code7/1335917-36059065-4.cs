    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FluentNHibernate;
    using NHibernate;
    using Npgsql;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate.Tool.hbm2ddl;
    
    namespace TelerikMvcApp1.Models
    {
        public class NHibernateHelper
        {
            public static ISession OpenSession()
            {
                ISessionFactory sessionFactory = Fluently
                    .Configure()
                    .Database(PostgreSQLConfiguration.PostgreSQL81
                    .ConnectionString(c => c.Is("Server=localhost;Port=5432;Database=/*your db name*/;User Id=/*your id*/;Password= /*your passwoed*/;"))
                    .ShowSql())
                    
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<GenreMap>())
                    
                    
    
                    .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                    .BuildSessionFactory();
                return sessionFactory.OpenSession();
    
            }
        }
    }
