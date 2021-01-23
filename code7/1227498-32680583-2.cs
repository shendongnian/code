    DataSet ds = new DataSet();
    
    using(SqlConnection conn = new SqlConnection(""data source=RAMANDEEP-PC\\SQLEXPRESS; initial catalog=RamandeepSingh; integrated security=true"))
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "select * from ContactManager";
        da.SelectCommand = cmd;
    
        conn.Open();
        da.Fill(ds);
    }
    
    listBox1.DataSource = ds.Tables[0];
    listBox1.DisplayMember = "Name"; // if you have any
    listBox1.ValueMember = "ID"; // if you have any
