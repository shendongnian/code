    using (SqlConnection conn = new SqlConnection("Connection string here..."))
    {
      string sqlcmd = "UPDATE table SET barcode = @newBarcode WHERE pk =  @reportId  SET @RowCount = @@ROWCOUNT;";
      
        conn.Open();
        SqlCommand cmd = new SqlCommand(sqlcmd, conn);
        
        cmd.Parameters.Add("@RowCount", SqlDbType.Int).Direction = ParameterDirection.Output;
        cmd.Parameters.Add(new SqlParameter("@newBarcode", newBarcode));
        cmd.Parameters.Add(new SqlParameter("@reportId", reportId));
    
        rowsUpdated = cmd.ExecuteNonQuery();
        int RowsAffected = Convert.ToInt32(cmd.Parameters["@RowCount"].Value);
      
       if (RowsAffected == 0)
        {
          throw new Exception("...");
         }
       else
        ......
     }
