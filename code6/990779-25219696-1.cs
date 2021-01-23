        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Application.StartupPath + "\\Login.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM " + comboBox1.Text;
            SqlDataAdapter dbAdapter = new SqlDataAdapter(cmd);
            DataTable dtRecords = new DataTable();
            dbAdapter.Fill(dtRecords);
            dataGridView1.DataSource = dtRecords; //dataGrid
            con.Close();
        }
