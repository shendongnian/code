    public DataTable GetSPRCombine(//Your Param)
    {
        var mySqlConnection = //Your Connection String
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
            cmd = new SqlCommand("SPRlist_GetSPRCombine", mySqlConnection);
            //Your command parameters
            mySqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
            Session["TaskTable"] = dt;
        }
