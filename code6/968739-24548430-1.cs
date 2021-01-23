    List<Article> costs = GetIdCosts(); //here there are 70.000 articles
    // Setup and open the database connection
    conn = new OleDbConnection(string.Format(MDB_CONNECTION_STRING, PATH, PSW));
    conn.Open();
    // Setup a command
    OleDbCommand cmd = new OleDbCommand();
    cmd.Connection = conn;
    cmd.CommandText = "UPDATE TABLE_RO SET TABLE_RO.COST = ? WHERE TABLE_RO.ID = ?;";
    
    // Setup the paramaters and prepare the command to be executed
    cmd.Parameters.Add("?", OleDbType.Currency, 255);
    cmd.Parameters.Add("?", OleDbType.Integer, 8); // Assuming you ID is never longer than 8 digits
    
    cmd.Prepare();
    OleDbTransaction transaction = conn.BeginTransaction();
    cmd.Transaction = transaction;
    // Start the loop    
    for (int i = 0; i < costs.Count; i++)
    {
        cmd.Parameters[0].Value = costs[i].Cost;
        cmd.Parameters[1].Value = costs[i].Id;
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            // handle any exception here
        }
    }
    transaction.Commit();
    conn.Close();
