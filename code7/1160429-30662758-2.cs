    public IEnumerable<T> CreateListOfItems(string tableName,
                                            Func<MySqlDataReader, T> itemCreator)
    {
        var items = new List<T>();
        using (var strConn = getMySqlConnection())
        {
            string query = "SELECT * FROM " + tableName;
            var cmd = new MySqlCommand(query, strConn);
            strConn.Open();
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                items.Add(itemCreator(rd));
            }
        }
        return items;
    }
