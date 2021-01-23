    DataTable dt = new DataTable();
    //Add Columns
    dt.Columns.Add("ID");
    dt.Columns.Add("Product");
    dt.Columns.Add("Description");
    //Add rows
    dt.Rows.Add("7J9P", "Soda", "2000ml bottle");
    
    using (conn)
    {
        SqlCommand cmd = new SqlCommand("dbo.INSERT_SP", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter dtparam = cmd.Parameters.AddWithValue("@INFO_ARRAY", dt);
        dtparam.SqlDbType = SqlDbType.Structured;
    }
