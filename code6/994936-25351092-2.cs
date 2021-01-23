    // Let's start with mapping-by-code,
    // so firstly create the Mapper
    var mapper = new NHibernate.Mapping.ByCode.ModelMapper();
    mapper.AddMappings(Assembly
        .GetAssembly(typeof(IdentityUser)) // here we have to get access to the mapping
        .GetExportedTypes());
    // create the mapping
    var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
    // standard Fluent configuration
    var fluentConfig = FluentNHibernate.Cfg.Fluently.Configure()
        .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
            .ConnectionString(@"Data Source=.;Database=TheCoolDB;Trusted_Connection=yes;"))
        .Mappings(m =>
            m.FluentMappings
                .AddFromAssemblyOf<MyAwesomeEntityMap>())
    // here we INJECT the HBM mapping
    // via call to built in ExposeConfiguration(Action<Configuration> config)
         .ExposeConfiguration(c => c.AddDeserializedMapping(mapping, null));
    // the ISessionFactory
    var factory = fluentConfig
        .BuildSessionFactory();
