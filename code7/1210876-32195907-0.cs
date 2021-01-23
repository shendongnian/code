    login.Clicked += delegate {
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=testdb;Uid=<your user>;Pwd=<your password>");
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM table;"
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(String.Format("{0}", reader[0]));
        }
        reader.Close();
        command.Close();
        connection.Close();
    };
