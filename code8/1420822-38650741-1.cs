    // define connection string and query
    string connStr = "--your connection string here--";
    // query has an "OUTPUT" clause to return a newly inserted piece of data
    // back to the caller, just as if a SELECT had been issued
    string query = "INSERT INTO dbo.Clients(ClientID, FirstName, LastName) OUTPUT Inserted.ClientID VALUES(NEWID(), @First, @Last);";
    using (SqlConnection conn = new SqlConnection(connStr))
    using (SqlCommand cmd = new SqlCommand(query, conn))
    {
        // set the parameters - note: you do *NOT* send in a GUID value - the NEWID() will create one automatically, on the server
        cmd.Parameters.Add("@First", SqlDbType.VarChar, 50).Value = "Frank";
        cmd.Parameters.Add("@Last", SqlDbType.VarChar, 50).Value = "Brown";
        // open connection
        conn.Open();
        
        // execute query and get back one row, one column - the value in the "OUTPUT" clause
        object output = cmd.ExecuteScalar();
        Guid newId;
        if (Guid.TryParse(output.ToString(), out newId))
        {
            //
        }
        conn.Close();
    }
