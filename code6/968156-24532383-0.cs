    using (conn)
    {
        SqlCommand cmd = new SqlCommand("usp_myproc", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        using(cmd)
        {
            cmd.Parameters.Add(new SqlParameter("@param", param));
            conn.Open();
            System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
        }
    }
