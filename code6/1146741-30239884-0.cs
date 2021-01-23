    using (OleDbConnection dbConnection = new OleDbConnection(strDeConexion))
    {
        using (OleDbCommand commandStatement = new OleDbCommand(queryInsertTable1, dbConnection))
        using (OleDbCommand commandIdentity = new OleDbCommand(queryGetLastId , dbConnection))
        {
            dbConnection.Open();
            foreach (int c in Collection)
            {
                commandStatement.Parameters.Clear();
                commandStatement.Parameters.AddWithValue("", c);
                commandStatement.ExecuteNonQuery();
                
                LastInsertedId = (int)commandIdentity.ExecuteScalar();
            }
        }
    }
