     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            OleDbConnection baglan = new OleDbConnection(@"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=C:\\users\\toshiba\\desktop\\proje-1; Extended Properties='Excel 12.0 xml;HDR=YES;'");
            baglan.Open();
           
            string sql_a = "SELECT * FROM [Sheet1$] where [City]=@City";
            OleDbCommand komut_a = new OleDbCommand(sql_a, baglan);
            komut_a.Parameters.AddWithValue("@City", comboBox1.SelectedItem.ToString());
            OleDbDataReader dr_a = null;
            dr_a = komut_a.ExecuteReader();
            string sql_b = "SELECT * FROM [Sheet1$B1:B1000]";
            OleDbCommand komut_b = new OleDbCommand(sql_b, baglan);
            OleDbDataReader dr_b = null;
            dr_b = komut_b.ExecuteReader();
            while (dr_a.Read() && dr_b.Read())
            {
                if (dr_a[0].ToString() == comboBox1.SelectedItem.ToString())
                {
                    if (!comboBox2.Items.Contains(dr_b[0].ToString()))
                    {
                        comboBox2.Items.Add(dr_b[0].ToString());
                    }
                }
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
            comm.CommandText = "SELECT * FROM[Sheet1$]  where Cafe like '%@Dormitory%'";
            comm.Parameters.AddWithValue("@Cafe",    comboBox2.SelectedItem.ToString());
            dAdpter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
