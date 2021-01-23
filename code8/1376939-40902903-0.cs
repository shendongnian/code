     static void Main(string[] args)
            {
    
                String connections = "Server=192.168.1.163;Port=5432;Database=postgres;User Id=postgres;Password=root;";
                NpgsqlConnection connection = new NpgsqlConnection();
                connection.ConnectionString = connections;
                connection.Open();
    
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO sector(name,address,designition,description,auto_id) values ('vinoth','chennai','sds','wdewd','123')";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();                                                        
                    cmd.Dispose();
    
                }
                catch (Exception e)
                {
                    e.ToString();
                }
    }
