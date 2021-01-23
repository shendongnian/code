    private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand rcmd = new SqlCommand("SELECT ID, Column1, Column2 FROM [TEST].[dbo].[Table_1] where ID=@ID", connection);
    
            rcmd.Parameters.AddWithValue("@ID", textBox3.Text);
            connection.Open();
            SqlDataReader reader = rcmd.ExecuteReader();
    
    
            while (reader.Read())
            {
    
                textBox4.Text = reader["Column1"].ToString();
                textBox5.Text = reader["Column2"].ToString();
    
            }
            connection.Close();
