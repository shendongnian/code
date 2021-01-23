    container.Register(Component.For<IDbRepository>()
        .ImplementedBy<DbRepository>()
        .LifeStyle.Singleton                
        .DynamicParameters((k,d) => 
        {
            var configProvider = k.Resolve<IConfigProvider>();
            d["connectionString"] = configProvider.GetConfig();
        }
    )));      
