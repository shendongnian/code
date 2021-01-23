    private const string dbConnection = "Provider=Microsoft.ACE.OLEDB.12.0;...";
    private const string query = "INSERT INTO...";
    using((OleDbConnection connection = new OleDbConnection(dbConnection))
         using(OleDbCommand command = new OleDbCommand(query, connection))
         {
              connection.Open();    
              // Parameter(s) here
              command.ExecuteNonQuery();
              // Any other logic here.
         }
