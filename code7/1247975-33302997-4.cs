    using(SqlConnection conn = new SqlConnection(ConnectionString ))
    using(SqlCommand cmd = new SqlCommand("dbo.sp_RandomPlace", conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
    
        // set up the parameters
        cmd.Parameters.Add("@OutputVar", SqlDbType.Nvarchar).Direction = ParameterDirection.Output;
    
        
    
        // open connection and execute stored procedure
        conn.Open();
        cmd.ExecuteNonQuery();
    
        // read output value from @OutputVar
        string place= Convert.ToString(cmd.Parameters["@OutputVar"].Value);
        conn.Close();
    }
