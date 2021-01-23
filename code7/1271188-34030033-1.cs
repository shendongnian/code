    string cmdText = @"SELECT * from TABLE_A;
                       SELECT * from TABLE_B";
    using(MySqlConnection cnn = new MySqlConnection(......))
    using(MySqlCommand cmd = new MySqlCommand(cmdText, cnn))
    {
        int curTable = 0;
        cnn.Open();
        using(MySqlDataReader reader = cmd.ExecuteReader())
        {
            do
            {
                while (reader.Read())
                {
    				if(curTable == 0)
    					Console.WriteLine("Update first list based on the first table");
    				else if(curTable == 1)
    					Console.WriteLine("Update second list based on second table");
                }
                Console.WriteLine("Go to next result");
    			curTable++;
            }
            while(reader.NextResult());
        }
    }
