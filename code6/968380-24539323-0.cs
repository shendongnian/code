      SqlConnection con = new SqlConnection("Data Source=RUSH-PC\\RUSH;Initial Catalog=Att;Integrated Security=True");
    
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select name from userinfo", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow dr;
                dr = dt.NewRow();
    
                dt.Rows.InsertAt(dr, 1);
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "name";
                comboBox1.DataSource = dt;    
                con.Close();
