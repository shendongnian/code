    DataTable dt = new DataTable();
    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
     {
        SqlCommand cmd = new SqlCommand("select * from testtable where id=@id", con);
        cmd.Parameters.AddWithValue("@id", id);
        SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
        dAdapter.Fill(dt);
     }
    foreach (DataColumn dc in dt.Columns)
     {
        listView1.Columns.Add(dc.ColumnName, 50, HorizontalAlignment.Left);
                        
     }
