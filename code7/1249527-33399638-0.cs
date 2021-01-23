    container.Register<IDbConnection>(() =>{ 
        var con = ConfigurationManager.ConnectionStrings["TrackerConnection"]; 
        if (con == null) 
            throw new Exception("Failed to find connection"); 
        var _provider = DbProviderFactories.GetFactory(con.ProviderName); 
        var connection = _provider.CreateConnection(); 
        if (connection == null) 
            throw new Exception($"Failed to create a connection using the connection string named '{con.ProviderName}' in app.config or web.config."); 
        connection.ConnectionString = con.ConnectionString; 
        return connection; 
    });
