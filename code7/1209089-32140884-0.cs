    private void button2_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\C #\InsertDeleteUpdate-Login\InsertDeleteUpdate-Login\Database1.mdf;Integrated Security=True"))
        using (SqlCommand cmd = new SqlCommand("UPDATE info SET Password=@Password WHERE Id=@Id AND Password=@Password1",conn))
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@Password", textBox4.Text);
            cmd.Parameters.AddWithValue("@Id", textBox3.Text);
            cmd.Parameters.AddWithValue("@Password1", textBox2.Text);
            cmd.ExecuteNonQuery();
            conn.close();
        }
    }
