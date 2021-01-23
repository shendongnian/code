    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();        
        
        using (var cmd = new SqlCommand("newBehzad", conn)
        {
            cmd.CommandType = CommandType.StoredProcedure;
        
            SqlParameter retval = new SqlParameter();
            retval.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = 2;  
            cmd.Parameters.Add(retval);
            cmd.ExecuteNonQuery();
            returnValue = (int)retval.Value;
        }
    }
