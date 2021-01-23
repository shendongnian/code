     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboBox2.Items.Clear();
        OleDbConnection baglan = new OleDbConnection(@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=C:\\users\\toshiba\\desktop\\proje-1; Extended Properties='Excel 12.0 xml;HDR=YES;'");
        baglan.Open();
        string sql_b = "SELECT * FROM [Sheet1$] where [city]=@city";		
        OleDbCommand komut_b = new OleDbCommand(sql_b, baglan);
		komut_b.Parameters.AddWithValue("@city", comboBox1.Text.ToString());
        OleDbDataReader dr_b = null;
        dr_b = komut_b.ExecuteReader();        
        while (dr_b.Read())
        {           
          comboBox2.Items.Add(dr_b[0].ToString());                
        }
        baglan.Close();
    }
    private void button1_Click(object sender, EventArgs e)
    {
    DataTable dt = new DataTable();
     OleDbConnection baglan = new OleDbConnection(@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=C:\\users\\toshiba\\desktop\\proje-1; Extended Properties='Excel 12.0 xml;HDR=YES;'");
    OleDbCommand comm = new OleDbCommand();
    OleDbDataAdapter dAdpter = new OleDbDataAdapter(comm);
    comm.Connection = baglan;
    comm.CommandText = "SELECT * FROM[Sheet1$]  where Cafe like @cafe";   
    comm.Parameters.AddWithValue("@cafe", "%" + comboBox2.Text.ToString() + "%"); 
    dAdpter.Fill(dt);
     datagridview.DataSource=dt;
    }
