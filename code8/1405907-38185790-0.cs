     // With a default parameter set to false you can still use
     // the same code as before and change only the spots where
     // the context is required
     protected IDbConnection OpenConnection(bool useContext = false)
     {
     
        string newConString = _connectionString;
        if(useContext)
        {
            SqlConnectionStringBuilder scs = new SqlConnectionStringBuilder(_connectionString);
            scs.ContextConnection = true;
            newConString = scs.ToString();
        }
        IDbConnection connection = new SqlConnection(newConString);
        connection.Open();
        return connection
    }
