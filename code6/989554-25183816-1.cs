     public class AirportClass
        {
            private string connectionString;
            private SqlConnection connection;
            private SqlCommand command;
            private List<string> items;
    
            public AirportClass()
            {
                connectionString = @"Server=server;database=database;uid=username;pwd=password;";
            }
    
            public List<string> getListItems()
            {
                items = new List<string>();
                connection = new SqlConnection(connectionString);
                command = new SqlCommand("SELECT * FROM Table");
                command.Connection = connection;
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string data = dataReader.GetString(0);
                    items.Add(data);
                }
                connection.Close();
                return items;
            }
        }
