    public DateTime getCurrentDate()
    {
        try
        {
            DateTime dt;
    
            // set up connection and command in *using* blocks
            using (SqlConnection objSqlConn = new SqlConnection(ConnString))
            using (SqlCommand cmd = new SqlCommand("dbo.usp_currentDate", objSqlConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
    
                objSqlConn.Open();
            
                // since the query returns exactly one row, one column -> use ExecuteScalar
                object result = cmd.ExecuteScalar();
                
                // if something was returned .....
                if (result != null)
                {
                    // try to convert to DateTime
                    if (DateTime.TryParse(result.ToString(), out dt)
                    {
                        return dt;
                    }
                }
                
                // return default value, if no data was read or could not be converted 
                return DateTime.MinValue;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    } 
