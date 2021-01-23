    OleDbConnection dbConnection = new OleDbConnection();
    dbConnection.ConnectionString = strDeConexion;
    dbConnection.Open();
    OleDbCommand commandStatement = new OleDbCommand();
    commandStatement.Connection = dbConnection;
    commandStatement.CommandText = query;
    commandStatement.ExecuteNonQuery();
    dbConnection.Close();
