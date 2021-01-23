    using (SqlConnection Connection = new SqlConnection("..."))
    using (SqlCommand Command = Connection.CreateCommand())
    {
        Command.CommandText = "SELECT Name, Surname FROM Users WHERE ID='2'";
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();
        var name = reader.GetString(0);
        var surname = reader.GetString(1);
        NameTextBox.Text = name;
        SurnameTextBox.Text = surname;
 
    }
