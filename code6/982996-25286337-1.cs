        con = new SqlConnection(conStr);    
        con.Open();    
        using (con)    {                
           // Configure the SqlCommand and SqlParameter.
           SqlCommand sqlCmd = new SqlCommand("czone.SetAccountEmailPreference", con);
           sqlCmd.CommandType = CommandType.StoredProcedure;
           SqlParameter tvpParam = sqlCmd.Parameters.AddWithValue("@UnsubscribeTypes", _dt); // TVP
           tvpParam.SqlDbType = SqlDbType.Structured; //tells ADO.NET we are passing TVP
           //pass other parameters
           sqlCmd.ExecuteNonQuery();
        }    
        con.Close();
