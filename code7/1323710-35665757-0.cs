    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NHibernate;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using ControleUsuarios.Map;
    using NHibernate.Tool.hbm2ddl;
    
    
    namespace ControleUsuarios.BD {
    
        public class BDConnect {
    
            private static ISessionFactory session;
            private static const String HOST = "localhost";
            private static const String USER = "root";
            private static const String PASSWORD = "";
            private static const String DB = "usuario_db";        
    
            /** create a connection with database */
            private static ISessionFactory createConnection() {
    
                if (session != null)
                    return session;
     
                //database configs
                FluentConfiguration _config = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(
                                                                           x => x.Server(HOST).
                                                                              Username(USER).
                                                                              Password(PASSWORD).
                                                                              Database(DB)
                                                                            ))
                                                                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
                                                                            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
    
                session = _config.BuildSessionFactory();
                return session;
            }
    
    
            /** open a session to make transactions */
            public static ISession openSession() {
                return createConnection().OpenSession();
            }
    
    
    
        }
    }
