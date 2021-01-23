    static DataSet sqlTest(string connectionString)
    {
        using (var sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            var sqlCommand = new SqlCommand("exec dbo.StoredProc", sqlConnection);
            var dataSet = new DataSet();
            var sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataSet, "Data");
            // you can access your values like that:
            var userId = dataSet.Tables["Data"].Rows[0][0];
            var count = dataSet.Tables["Data"].Rows[0][1];
            return dataSet;
        }
    }
