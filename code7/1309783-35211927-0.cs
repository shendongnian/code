    String strConnString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    using(SqlConnection con = new SqlConnection(strConnString))
    using(SqlCommand cmd = new SqlCommand("usp_InsertData", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.Add("@FirstIssue", SqlDbType.NVarChar);
        .... add the other parameters specifying the correct datatype .....
        for (int i = 1; i < dt.Rows.Count; i++)
        {
            cmd.Parameters["@FirstIssue"].Value = dt.Rows[i][0].ToString());
            ... other parameters values follows here ....
            // If you don't use the exception don't catch it....
            cmd.ExecuteNonQuery();
        }
    }
