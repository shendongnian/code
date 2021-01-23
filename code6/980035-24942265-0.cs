    using (var conn = new OleDbConnection())
    {
        conn.ConnectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=C:\__tmp\testData.accdb;";
        conn.Open();
        using (var cmd = new OleDbCommand())
        {
            cmd.Connection = conn;
            cmd.CommandText =
                "UPDATE Table1 SET ProductType = Replace(ProductType, ' ', '')";
            cmd.ExecuteNonQuery();
        }
        conn.Close();
    }
