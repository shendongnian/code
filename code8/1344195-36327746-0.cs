    container.RegisterType<IMetaDataConnectionStringLoader, ConnectionStringLoader>("bar", new InjectionConstructor("MetaConnection"));
    container.RegisterType<IDbConnectionStringLoader, ConnectionStringLoader>("foo", new InjectionConstructor("DbConnection"));
    
    var foo = container.Resolve<IDbConnectionStringLoader>("foo");
    var bar = container.Resolve<IMetaDataConnectionStringLoader>("bar");
