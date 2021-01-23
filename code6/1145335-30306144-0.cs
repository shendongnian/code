    using NHCfg = NHibernate.Cfg;
    
    var config = new Configuration().AddMappingsFromAssembly<Entity>();
    if (UseSqlCe)
    {
        config.SetProperty(NHCfg.Environment.Driver, typeof(SqlCeDriver).AssemblyQualifiedName);
        config.SetProperty(NHCfg.Environment.Dialect, typeof(SqlCeDialect).AssemblyQualifiedName);
    }
    else if (UseSqlite)
    {
        config.SetProperty(NHCfg.Environment.Driver, typeof(Sqlite20Driver).AssemblyQualifiedName);
        config.SetProperty(NHCfg.Environment.Dialect, typeof(SqliteDialect).AssemblyQualifiedName);
    }
