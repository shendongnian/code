    public List<T> BuildModel<T>(string query) where T : new()
    {
        var container = new List<T>();
        
        var properties = typeof(T).GetProperties();
        
        using (var connection = new SqlConnection(dbConnection))
        using (var adapter = new SqlDataAdapter(query, connection))
        {
            connection.Open();
            
            var table = new DataTable();
            
            adapter.Fill(table);
            
            foreach (DataRow row in table.Rows)
            {
                T item = new T();
            
                foreach (PropertyInfo property in properties)
                {
                    if (table.Columns.Contains(property.Name))
                    {
                        property.GetSetMethod().Invoke(item, new[] { row[property.Name] });
                    }
                }
                
                container.Add(item);
            }
        }
        
        return container;
    }
