    DataTable dt = new DataTable();
    using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
     {
        SqlCommand cmd = new SqlCommand("SELECT `entry`, `name` FROM `accounts` WHERE `name` LIKE %@name%", con);
        cmd.Parameters.AddWithValue("@name", "somename");
        SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
        dAdapter.Fill(dt);
     }
    foreach (DataColumn dc in dt.Columns)
     {
        listView1.Columns.Add(dc.ColumnName, 50, HorizontalAlignment.Left);
                        
     }
