    //Set default connection
    var dbFactory = new OrmLiteConnectionFactory(
        "~/App_Data/db.sqlite".MapAbsolutePath(), SqliteDialect.Provider);
    //Setup multiple named connections
    dbFactory.RegisterConnection("db1", 
        "~/App_Data/db1.sqlite".MapAbsolutePath(), SqliteDialect.Provider);
    dbFactory.RegisterConnection("db2", 
        "~/App_Data/db2.sqlite".MapAbsolutePath(), SqliteDialect.Provider);
