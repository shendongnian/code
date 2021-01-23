    SqlCommand cmd;
    Using(SqlConnection Con = new SqlConnection("ConnectionString")
    {
        cmd = new SqlCommand("StoredProcedureName", Con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        Con.Open();
        SqlCommandBuilder.DeriveParameters(cmd);
        Con.Close();
    }
