    SqlConnection dbConnection;
    using (dbConnection = new SqlConnection(connectionString))
    {
        dbConnection.Open();
        // Whatever Dapper stuff you want to do
        dbConnection.Close();
     }
