     using (SqlDataAdapter da = new SqlDataAdapter())
       {
        da.SelectCommand = new SqlCommand();
        da.SelectCommand.Connection.ConnectionString= con.ConnectionString;
        ..
       }
                     
