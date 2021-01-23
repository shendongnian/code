    System.Data.Entity.Migrations.DbMigrationsConfiguration configuration;
    switch (ConfigurationManager.AppSettings["DatabaseProvider"].ToUpper())
    {
        case "MYSQL":
            configuration = new Migrations.MySQL.Configuration();
            configuration.MigrationsNamespace = "Server.Migrations.MySQL";
            break;
        case "MSSQL":
            configuration = new Migrations.MSSQL.Configuration();
            configuration.MigrationsNamespace = "Server.Migrations.MSSQL";
            break;
        default:
            throw new Exception("Invalid DatabaseProvider, please check your config");
    }
    configuration.ContextType = typeof(Context);
    configuration.MigrationsAssembly = configuration.ContextType.Assembly;
    var migrator = new System.Data.Entity.Migrations.DbMigrator(configuration);
    migrator.Update();
