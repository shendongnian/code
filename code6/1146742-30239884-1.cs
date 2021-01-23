    using (OleDbConnection dbConnection = new OleDbConnection(strDeConexion))
    {
        using (OleDbCommand commandStatement = new OleDbCommand(queryInsertTable1, dbConnection))
        using (OleDbCommand commandIdentity = new OleDbCommand(queryGetLastId , dbConnection))
        {    
            commandStatement.Parameters.Add(new OleDbParameter());
            dbConnection.Open();
            foreach (int c in Collection)
            {
                commandStatement.Parameters[0].Value = c;
                commandStatement.ExecuteNonQuery();
                
                LastInsertedId = (int)commandIdentity.ExecuteScalar();
            }
        }
    }
