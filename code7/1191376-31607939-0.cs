    private void button1_Click(object sender, EventArgs e)
    {
        using(var connection = new OleDbConnection(conString))
        using(var command = connection.CreateCommand())
        {
            command.CommandText = @"INSERT INTO [student table]([Name],[Class]) 
                                    VALUES(?, ?)";
            command.Parameters.AddWithValue("?", textBox1);
            command.Parameters.AddWithValue("?", textBox2);
            
            connection.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Data Saved");  
        }        
    }
