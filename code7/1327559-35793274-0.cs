     DbMigrationsConfiguration configuration = new DbMigrationsConfiguration()
    {
    	MigrationsAssembly = typeof(YOURASSEMBLY).Assembly,
    	ContextType = typeof(YOURASSEMBLY),
    	TargetDatabase = new System.Data.Entity.Infrastructure.DbConnectionInfo(__YOUR_CONNECTION_STRING__)
    };
    
    DbMigrator dbMigrator = new DbMigrator(configuration);
    dbMigrator.Update();
