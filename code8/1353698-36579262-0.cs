            var databaseName = "Test";
            var databaseFile = "Test.mdf";
            if(!File.Exists(databaseFile))
            {
                var connectionString = @"Data Source=(LocalDB)\v11.0;Integrated Security=True;";
                var query = $@"
                    CREATE DATABASE {databaseName} ON PRIMARY (
                        NAME = '{databaseName}',
                        FILENAME = '{databaseFile}');";
                using(var connection = new SqlConnection(connectionString))
                {
                    using(var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Created database!");
            }
