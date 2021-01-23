    private List<T> Build<T>(string query) where T : new()
    {
        var container = new List<T>();
        using(var connection = new SqlConnection(dbConnection))
            using(var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using(var reader = command.ExecuteReader())
                    while(reader.Read())
                    {
                        T model = new T();
                        var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                        var type = model.GetType();
                        foreach(var property in type.GetProperties())
                            foreach(var column in columns)
                                if (String.Compare(property.Name, column, true) == 0)
                                    if(!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                                        property.SetValue(model, reader.GetValue(reader.GetOrdinal(property.Name)), null);
                            
                        container.Add(model);
                    }
            }
        return container;
    }
