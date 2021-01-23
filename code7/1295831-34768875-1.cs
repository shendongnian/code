    protected void RunSQLQuery(string salesman, string connectionString)
    {
        using(var cnn = new SqlConnection(connectionString))
        using(var cmd = cnn.CreateCommand())
        {
             cmd.CommandText = @"update database set shippdate = GetDate() 
                                 where salesman = @salesman";
             cmd.Parameters.Add("@salesman", salesman);
             cnn.Open();
             cmd.ExecuteNonQuery();
        }
    }
