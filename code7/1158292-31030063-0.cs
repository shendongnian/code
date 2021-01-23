       ISessionFactory factory = Fluently.Configure()
                              .Database(
                    IfxSQLIConfiguration
                   .Informix1000
                  .ConnectionString("Provider=Ifxoledbc.2;Password=xxxx;Persist Security Info=True;User ID=xxxx;Data Source=xxxx")
                                 .Driver<OleDbDriver>()
                   .Dialect<InformixDialect1000>()
                   .ShowSql())
                   .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ArtistaFotoMapping>()
                   ).ExposeConfiguration(x =>
                      x.SetProperty(NHibernate.Cfg.Environment.PrepareSql, "True")
                   )
                   .BuildSessionFactory();` 
