    private void button2_Click(object sender, EventArgs e)
    {
        // Adding Data to Database
        string query = "INSERT INTO Results VALUES (@First), (@Second), (@Third), (@Fourth), (@Fifth), (@Sixth)";
        using (var connection = new SqlConnection(connectionString))
    	{
    		using (SqlCommand command = new SqlCommand(query, connection))
    		{
    			connection.Open();
    			command.Parameters.AddWithValue("@First", textBox1.Text);
    			command.Parameters.AddWithValue("@Second", textBox2.Text);
    			command.Parameters.AddWithValue("@Third", textBox3.Text);
    			command.Parameters.AddWithValue("@Fourth", textBox4.Text);
    			command.Parameters.AddWithValue("@Fifth", textBox5.Text);
    			command.Parameters.AddWithValue("@Sixth", textBox6.Text);
    			
    			command.ExecuteNonQuery();
    
    		}
    	}
    }
