      DataTable dt = new DataTable();
     ...
    using (SqlDataAdapter a = new SqlDataAdapter( new SqlCommand(query, conn)))
                      {
                          GridView2.DataSource =a.Fill(dt).AsDataView();
                      }
