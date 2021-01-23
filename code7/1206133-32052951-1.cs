    using(SqlConnection connection = new SqlConnection("[your connection string here]"))
    {
      connection.Open();
    
      using (SqlCommand command = connection.CreateCommand())
      {
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "dbo.SelectDays";
    
        command.Parameters.AddWithValue("@dateStart", dateStart != null ? (object)dateStart : DBNull.Value);
        command.Parameters.AddWithValue("@dateEnd", dateEnd != null ? (object)dateEnd : DBNull.Value);
    
        SqlParameter out_recordCount = new SqlParameter("@recordCount", SqlDbType.BigInt);
        out_recordCount.Direction = ParameterDirection.InputOutput;
        out_recordCount.Value = recordCount;
    
        command.Parameters.Add(out_recordCount);
    
        SqlParameter return_Value = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
        return_Value.Direction = ParameterDirection.ReturnValue;
        command.Parameters.Add(return_Value);
    
        using(SqlDataReader reader = command.ExecuteReader())
        {
          while(reader.Read()) { /* do whatever with result set data here */ }
        }
    
        /* Output and return values are not available until here */
    
        if (out_recordCount.Value != DBNull.Value)
          recordCount = Convert.ToInt64(out_recordCount.Value);
    
        returnValue = Convert.ToInt32(return_Value.Value);
    
        return returnValue;
      }
    }
