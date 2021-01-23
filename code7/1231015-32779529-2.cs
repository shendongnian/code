    dynamic dbSet = dbContext
                           .GetType()
                           .GetProperty(tableName, BindingFlags.Public | BindingFlags.Instance)
                           .GetValue(dbContext, null);
    dbSet.Add(someEntity);
