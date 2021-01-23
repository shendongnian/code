     string TotalCost = row.Cells[6].ToString(); 
     decimal cost;
     if(!decimal.TryParse(TotalCost, out cost))
         // Put here an error message for your user
         // "The value cannot be converted to a decimal value"
     else
     {
        using (SqlConnection myCon = new SqlConnection(myConnStr))
        using (SqlCommand myCmd = new SqlCommand())
        {
            myCmd.Connection = myCon;
            myCmd.CommandType = CommandType.Text;
            myCmd.CommandText = @"insert into myTable (FullName, TotalCost ) 
                                  values(@FullName, @TotalCost)";
            myCmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = FullName;
            myCmd.Parameters.Add("@TotalCost", SqlDbType.Decimal).Value = cost;
            myCon.Open();
            myCmd.ExecuteNonQuery();
       }
    }
