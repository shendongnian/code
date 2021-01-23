    // standard Fluent configuration
    var fluentConfig = FluentNHibernate.Cfg.Fluently.Configure()
        .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008
            .ConnectionString(@"Data Source=.;Database=TheCoolDB;Trusted_Connection=yes;"))
        .Mappings(m =>
            m.FluentMappings
                .AddFromAssemblyOf<MyAwesomeEntityMap>());
    // return the NHibernate.Cfg.Configuration
    var config = fluentConfig
        .BuildConfiguration();
            
    // now Mapping by Code
    // firstly the Mapper
    var mapper = new NHibernate.Mapping.ByCode.ModelMapper();
    mapper.AddMappings(Assembly
        .GetAssembly(typeof(IdentityUser)) // here we have to get access to the mapping
        .GetExportedTypes());
    // finally the mapping just read
    var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
    // extend already existing mapping
    config.AddDeserializedMapping(mapping, null);
    // the ISessionFactory
    var factory = config.BuildSessionFactory();
