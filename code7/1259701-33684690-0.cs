    ConnectionStringSettings conn = ConfigurationManager.ConnectionStrings["MyConnectionString"];
    if (conn == null || string.IsNullOrEmpty(conn.ConnectionString)) 
    {
        throw new Exception("Couln't find connection string in web.config.");
    }
    myConnString = conn.ConnectionString
