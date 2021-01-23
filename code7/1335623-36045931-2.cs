    var configuration = new NHibernate.Cfg.Configuration();
    ...
    configuration.AddProperties(
        new Dictionary<string, string>
        {
            { "default_schema", "yourDbName.yourSchema" }
        });
    ...
    var sessionFactory = configuration.BuildSessionFactory();
