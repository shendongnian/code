       SqlCommand cmd = new SqlCommand("reading");
       cmd.CommandType = CommandType.StoredProcedure;
       using(SqlDataReader ourreader = conn.ReadMe(cmd))
            {
             while (ourreader.Read())
                   {
                   //some code
                   }
            }
       conn.Close();
        
