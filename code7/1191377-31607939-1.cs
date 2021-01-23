    private void button1_Click(object sender, EventArgs e)
    {
        using(var connection = new OleDbConnection(connection))
        using(var command = connection.CreateCommand())
        {
            command.CommandText = @"INSERT INTO [student table]([Name],[Class]) 
                                    VALUES(?, ?)";
            command.Parameters.AddWithValue("?", textBox1);
            command.Parameters.AddWithValue("?", textBox2);
            
            connection.Open();
            int count = command.ExecuteNonQuery(); 
            if(count > 0)
               MessageBox.Show("Data Saved");  
        }        
    }
