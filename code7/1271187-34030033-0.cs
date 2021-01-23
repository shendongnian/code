    string cmdText = @"SELECT * from TABLE_A;
                       SELECT * from TABLE_B";
    using(MySqlConnection cnn = new MySqlConnection(......))
    using(MySqlCommand cmd = new MySqlCommand(cmdText, cnn))
    {
        cnn.Open();
        using(MySqlDataReader reader = cmd.ExecuteReader())
        {
            do
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
                Console.WriteLine("Go to next result");
            }
            while(reader.NextResult());
        }
    }
