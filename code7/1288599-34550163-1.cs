     DataTable dt = new DataTable();
     using (SqlConnection sqlConn = new SqlConnection(connectionString))
     {
         using (SqlCommand cmd = new SqlCommand("SELECT * FROM Holidays", sqlConn))
         {
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             da.Fill(dt);
         }
     }
