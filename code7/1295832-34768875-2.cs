    protected void RunSQLQuery(string salesman, string connectionString)
    {
        using(var cnn = new SqlConnection(connectionString))
        using(var cmd = cnn.CreateCommand())
        {
             cmd.CommandText = @"update database set shippdate = GetDate() 
                                 where salesman = @salesman";
             // I assume your column is nvarchar
             cmd.Parameters.Add("@salesman", SqlDbType.NVarChar).Value = salesman;
             cnn.Open();
             cmd.ExecuteNonQuery();
        }
    }
