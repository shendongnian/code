    string expr = "sp_YourProcedure";
    DataSet ds = new DataSet();
    using (SqlConnection Conn = new SqlConnection(YourConnString))
    {
        using (SqlCommand sCommand = new SqlCommand(expr, Conn))
        {
            sCommand.CommandType = CommandType.StoredProcedure;
            sCommand.CommandTimeout = 600; // set CommandTimeout here
            SqlDataAdapter sdAdapter = new SqlDataAdapter(sCommand);
            sdAdapter.Fill(ds);
        }
    }
