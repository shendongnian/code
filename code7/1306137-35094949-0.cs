      SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            
            cmd.CommandText = "StoredProcedureName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            
            sqlConnection1.Open();
            
            reader = cmd.ExecuteReader();
            
        while (reader.Read() != null)  // Each row from StoredProcedure
        {
           var returnObject = reader.GetString(0);
        
          ...
        {
            sqlConnection1.Close();
