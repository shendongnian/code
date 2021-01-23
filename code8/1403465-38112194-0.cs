    //SQL Server
    var dbFactory = new OrmLiteConnectionFactory(connectionString,  
        SqlServerDialect.Provider);
    
    //InMemory Sqlite DB
    var dbFactory = new OrmLiteConnectionFactory(":memory:", 
        SqliteDialect.Provider); 
