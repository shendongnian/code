        try
        {
            // Create and open the connection
            sql = new SqlConnection(connection);
            if (sql.State != System.Data.ConnectionState.Open)
            {  sql.Open();
            return new Result(true, "Connect to Database", "Connected to database [" + connection + "]"); }    
