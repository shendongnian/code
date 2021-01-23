    public String CountNewFolder()
    {
        tempInt = 0;
    
        using (SqlConnection sqlCon = new SqlConnection(connString))
        {
    	  using(SqlCommand sqlComm = new SqlCommand("USP_NEWFOLDER_COUNT", sqlCon))
    	  {
    		sqlComm.CommandType = CommandType.StoredProcedure;
    
    		sqlComm.Parameters.Add("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;
    
    		sqlCon.Open();
    		sqlComm.ExecuteNonQuery();
    
    		tempInt = Convert.ToInt32(sqlComm.Parameters["@Count"].Value);
    	  }
        }
    
        return tempInt.ToString();
    }
