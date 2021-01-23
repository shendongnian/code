        private void insertBttn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NUC\MICROGARDE;Initial Catalog=SQL;Integrated Security=True");
    
            int i = 0;
            con.Open();
            for (i = 0; i < this.dataGridView1.Rows.Count; i++)
            { 
                string query = "insert into " + comboBox1.SelectedValue.ToString() + " (@" + dataGridView1.Columns[i] + ") VALUES ('" + this.dataGridView1.Columns[i] + "');";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter(@Field, "value"));
                cmd.Parameters.Add(new SqlParameter(@Field, "value"));
                cmd.ExecuteNonQuery();
            }
            con.Close();
         }
