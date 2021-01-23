    foreach(var g in groups)
    {
    
        var dataItemType = g.Key;
        var listType = typeof(List<>).MakeGenericType(new [] { dataItemType });
        var list = (IList) Activator.CreateInstance(listType);
        
        foreach(var data in g)
            list.Add(data);
    
        db.Data.GetType()
               .GetMethod("InsertBulk")
               .MakeGenericMethod(dataItemType)
               .Invoke(db.Data, new object[] { list });
    
    }
