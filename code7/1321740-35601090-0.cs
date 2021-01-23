    var connectionString = 
        ConfigurationManager.ConnectionStrings["LogDbContext"].ConnectionString;
    using(var sqlConn = new OracleConnection(connectionString))
    {
        // ...
    }
