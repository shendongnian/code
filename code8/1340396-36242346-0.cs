    public IEnumerable<File> Get()
    {
        List<File> list = new List<File>();
        try
        {
            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Files";
            conn.Open();
    
            using(MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    //How to output the rows ????
                    int id = (int) reader["Id"];//Assuming column name is 'Id' and value if typeof(int)
                    string text = (string) reader["Text"];//Assuming column name is `Text` and typeof(string)
                    var file = new File {Id = is, Text = text};
                    list.Add(file);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    
        return list; // return the list
    }
