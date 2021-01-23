    var connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
    
    using (var sqlConnection = new SqlConnection(connectionString))
    {
        sqlConnection.Open();
        string sql = "SELECT * FROM MyTable WHERE ID = 1";
        using (var sqlCommand = new SqlCommand(sql, sqlConnection))
        {
            using (var sqlDataReader = sqlCommand.ExecuteReader())
            {
                while (sqlDataReader.Read())
                {
                    // This fails because the data reader has no results.
                    var id = sqlDataReader.GetInt32(0);
                }
            }
        }
    }
