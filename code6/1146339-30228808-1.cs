    try
    {
        // Create and open the connection
        sql = new SqlConnection(connection);
        if (sql.State != System.Data.ConnectionState.Open)
        {  
            sql.Open();
        }
        return new Result(true, "Connect to Database", "Connected to database [" + connection + "]"); 
    }    
    catch (Exception e) 
    {
        return new Result(false, "Connect to Database", "Could not connect to database [" + connection + "] " + e.ToString());
    }
