        SqlConnection conn =new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString);
        conn.Open();
        string query = ""Select * from Admin"";
        SqlCommand cmd = new SqlCommand(query, conn);
        DataTable t1 = new DataTable();
        using (SqlDataAdapter a = new SqlDataAdapter(cmd))
        {
            a.Fill(t1);
        }
        BindingSource bSource1 = new BindingSource();
    
        bSource1.DataSource = dbdataset1;
        adminGridView.DataSource = bSource1;
        sda1.Update(dbdataset1);
    
        adminGridView.Columns[0].Width = 92;
        adminGridView.Columns[1].Width = 200;
        adminGridView.Columns[2].Width = 180;
        adminGridView.Columns[3].Width = 180;
        adminGridView.Columns[4].Width = 170;
        adminGridView.Columns[5].Width = 130;
        adminGridView.Columns[6].Width = 170;
