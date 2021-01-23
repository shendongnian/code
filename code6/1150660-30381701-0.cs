         private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * FROM ProductDetails";
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                if (reader["proName"].ToString().Contains(textBox1.Text))
                {
                    listBox1.Items.Add(reader["proName"].ToString());
                }
                
            }
            connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * FROM ProductDetails";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["proName"].ToString().Contains(textBox1.Text))
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, 0].Value = reader["proName"].ToString();
                }
               
            }
            connection.Close();
        }
