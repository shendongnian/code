     private void button2_Click(object sender, EventArgs e)
        {
            //dataSet31.Personal_Details.Clear();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataAdapter sqlDataAdapter =
    new SqlDataAdapter(cmd.CommandText = "select * from vtypes WHERE VoucherType ='" + comboBox1.Text + "' AND VouOrder = '" + textBox1.Text + "'",
        "Data Source=SQLEXPRESS;Initial Catalog=DB50A0;Integrated Security=True"))
            {
                using (DataTable dataTable = new DataTable())
                {
                    sqlDataAdapter.Fill(dataTable);
                    this.dataGridView1.DataSource = dataTable;
                }
            }
        }
