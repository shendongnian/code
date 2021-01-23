     try
     {
         using (SqlConnection conn = new SqlConnection(connectionString.ConnectionString))
         {
             conn.Open();
             using (SqlCommand cmd = new SqlCommand("spr_Reports_JobsBreakdown4 ", conn))
             {
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add(new SqlParameter("@user", user));
                 cmd.Parameters.Add(new SqlParameter("@datefrom", dateFrom));
                 cmd.Parameters.Add(new SqlParameter("@dateto", dateTo));
                 reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                    //use reader to read in each returned row
                 }
                 reader.close();
             }
         }
      }
      catch(Exception ex){
         //handled exception
      }
