    private SqlCommand CreateCommand(SqlConnection connection)
    {
       return new SqlCommand("select * from instrutor", connection);
    }
    
    private SqlCommand CreateCommand(SqlConnection connection, TextBox textBox)
    {
        var command = new SqlCommand("select * from instrutor where Nome = @nome",  
            connection);
    
        command.Parameters.AddWithValue("@nome", textBox.text);
        return command;
    }
    
    private void textBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        // ...
        using (var command = !string.IsNullOrEmpty(textBox.Text) ? 
            CreateCommand(conn, textBox) : CreateCommand(conn))
        {
            // ...
        }
        // ...
    }
