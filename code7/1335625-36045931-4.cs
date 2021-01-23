    var configuration = new NHibernate.Cfg.Configuration();
    ...
    configuration.AddProperties(
        new Dictionary<string, string>
        {
            { NHibernate.Cfg.Environment.DefaultSchema, "yourDbName.yourSchema" }
        });
    ...
    var sessionFactory = configuration.BuildSessionFactory();
