    public static DataTable ExecuteSQLReturnDataTable(string sql, CommandType cmdType, params SqlParameter[] parameters)
    {
        using (DataSet ds = new DataSet())
        using (SqlConnection connStr = new SqlConnection(YourConnStr))
        using (SqlCommand cmd = new SqlCommand(sql, connStr))
        {
            cmd.CommandType = cmdType;
            cmd.CommandTimeout = EXTENDED_TIMEOUT;
            foreach (var item in parameters)
            {
                cmd.Parameters.Add(item);
            }
    
            cmd.Connection.Open();
            new SqlDataAdapter(cmd).Fill(ds);
            return ds.Tables[0];
        }
    }
