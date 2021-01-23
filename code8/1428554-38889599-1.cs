    using(SqlConnection connection=new SqlConnection(connection_string))
    {
        connection.Open();
        tran = connection.BeginTransaction();
        cmd = new SqlCommand(query1, connection, tran);
        cmd1 = new SqlCommand(query2, connection, tran);
        count = cmd.ExecuteNonQuery();
        count = count + cmd1.ExecuteNonQuery();
        tran.Commit();
    }
