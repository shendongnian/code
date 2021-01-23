    T entity = new T();
    
        TableQuery<T> query = new TableQuery<T>();
        
        var tableSet = table.ExecuteQuery(query).ToList();
        
        Random rnd = new Random();
        
        if (tableSet.Count >= 1)
        {
            return tableSet.ElementAt(rnd.Next(1, tableSet.Count));
        }
        
        return null;
