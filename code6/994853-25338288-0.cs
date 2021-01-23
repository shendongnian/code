    string sql = "SELECT COUNT(1) FROM MasterCompliant WHERE Discom = ?";
    int count;
    // Open and close a connection each time you need one - let the connection pool
    // handle making that efficient.
    using (var connection = new OleDbConnection(...))
    {
        connection.Open();
        using (var command = new OleDbCommand(sql, conn))
        {
            command.Parameters.Add("@v", OleDbType.VarChar).Value = discom1.Text;
            count = (int) command.ExecuteScalar();
        }
    }
