    object dbSet = dbContext
                       .GetType()
                       .GetProperty(tableName, BindingFlags.Public | BindingFlags.Instance)
                       .GetValue(dbContext, null);
    
    dbSet.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance)
         .Invoke(new object[] { someEntityTypedAsObject }); 
