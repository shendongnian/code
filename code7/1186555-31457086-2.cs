    // define connection and command, in using blocks to ensure disposal
    using(SqlConnection conn = new SqlConnection(pvConnectionString ))
    using(SqlCommand cmd = new SqlCommand("dbo.spLogin", conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
    
        // set up the input parameters
        cmd.Parameters.Add("@ClientUsername", SqlDbType.VarChar, 20);
        cmd.Parameters.Add("@ClientPassword", SqlDbType.Int);
        cmd.Parameters.Add("@Security", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@ClientFirstName", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("@Success", SqlDbType.Int).Direction = ParameterDirection.Output;
    
        // set parameter values
        cmd.Parameters["@ClientUsername"].Value = UserNamTextbox.Text;
    
        // open connection and execute stored procedure
        conn.Open();
        cmd.ExecuteNonQuery();
    
        // read output value from @Security
        int Security = Convert.ToInt32(cmd.Parameters["@Security"].Value);
        
        if Security == 1 ....... and so on.......
        
        conn.Close();
    }
