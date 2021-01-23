     SqlConnection sqlConn;
     using (var sqlConnection = new SqlConnection())
     {
        sqlConn = sqlConnection;
        sqlConnection.Open();
     }
     sqlConn.Close();
