    SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    
    cmd.CommandText = "StoredProcedureName";
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Connection = sqlConnection1;
    
    
    //ADD parameters and return value
    
      cmd.Parameters.AddWithValue("par1Name", "par1Value");
    
        var returnParameterVariable = cmd.Parameters.Add("@ReturnVal", SqlDbType.NVarChar);
        returnParameterVariable .Direction = ParameterDirection.ReturnValue;
    
    sqlConnection1.Open();
    
    reader = cmd.ExecuteReader();
    
    sqlConnection1.Close();
