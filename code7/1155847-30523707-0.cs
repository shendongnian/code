     private void button1_Click(object sender, EventArgs e)
        {
    using (cn)
    {
    
            SqlCeCommand cm = new SqlCeCommand("INSERT INTO tblUsers(userName, age) VALUES (@userName, @age)", cn);
            cm.Parameters.AddWithValue("@userName", textBox1.Text);
            cm.Parameters.AddWithValue("@age", textBox2.Text);
    
            try
            {
    cn.open();
                int affectedRows = cm.ExecuteNonQuery();
    
                if (affectedRows > 0)
                {
                    MessageBox.Show("Insert success!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Insert failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
