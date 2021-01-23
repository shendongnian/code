     // Wrap IDisposable into using 
     using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.Conn)) {
       conn.Open();
    
       // Make sql 
       //  1. Readable 
       //  2. Parametrized
       //  3. Avoid * in select
       String sql = 
         @"select UserID,
                  IsAdmin
             from Users
            where UserID = @prm_UserId";
    
       // Wrap IDisposable into using 
       using (SqlCommand cmd = new SqlCommand(sql, conn)) {
         // Explicit data type will be better here (Add Parameter with type)
         // but I don't know it
         cmd.Parameters.AddWidthValue("prm_UserId", t.Text);  
    
         // Wrap IDisposable into using 
         using (SqlDataReader reader = cmd.ExecuteReader()) {
           // You don't want to iterate the whole cursor, but the first record 
           if (reader.Read()) {
             //TODO: Make UserID being "long"
             user.UserID = Convert.ToInt64(reader["UserID"]);
             user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);
           } 
         }
       }
     } 
