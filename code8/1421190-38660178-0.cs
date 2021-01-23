     using (SqlConnection con = new SqlConnection(dc.Con))
     {
        using (SqlCommand cmd = new SqlCommand("_spInsertwarnings", con))
        {
          cmd.CommandType = CommandType.StoredProcedure;
    
    //Please Make SqlDataType as per your Sql ColumnType
          cmd.Parameters.Add("@idUser", SqlDbType.VarChar).Value = userIDAuth;
          cmd.Parameters.Add("@idPass", SqlDbType.VarChar).Value = idPass;
         
    
          con.Open();
          cmd.ExecuteNonQuery();
        }
      }
