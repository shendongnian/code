    SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(
         connectionStrings.ConnectionStrings["MyConnectionString"]);   
    using (SqlConnection conn = new SqlConnection(scsb.ConnectionString);
       {
            conn.Open();
            using (SqlCommand comm = new SqlCommand("SELECT name, id FROM product1", conn))
            {
               using (SqlDataReader reader = comm.ExecuteReader())
               {
                  while (reader.Read())
                  {
                         ...
                  }
               }
            }
        }
