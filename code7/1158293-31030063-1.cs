      ISessionFactory factory = Fluently.Configure()
      .Database(
        IfxOdbcConfiguration
        .Informix1000
        .ConnectionString("DRIVER={IBM INFORMIX ODBC DRIVER};SERVER=xxxx;DATABASE=xxxx;UID=xxx;PWD=xxx;NEEDODBCTYPESONLY=1;")
        .ShowSql())
        .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ArtistaFotoMapping>()
        ).ExposeConfiguration(x =>
           x.SetProperty(NHibernate.Cfg.Environment.PrepareSql, "False")
        )
        .BuildSessionFactory();
