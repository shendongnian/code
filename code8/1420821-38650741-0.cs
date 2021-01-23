    // define connection string and query
    string connStr = "--your connection string here--";
    string query = "INSERT INTO dbo.Clients(ClientID, FirstName, LastName) VALUES(@ID, @First, @Last);";
    using (SqlConnection conn = new SqlConnection(connStr))
    using (SqlCommand cmd = new SqlCommand(query, conn))
    {
        // create the GUID in C# - this is the ID - no need to go get it again - this *IS* the id
        Guid id = Guid.NewGuid();
        // set the parameters
        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = id;
        cmd.Parameters.Add("@First", SqlDbType.VarChar, 50).Value = "Peter";
        cmd.Parameters.Add("@Last", SqlDbType.VarChar, 50).Value = "Miller";
        // open connection, execute query, close connection
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
