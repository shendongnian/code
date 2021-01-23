    IList<object> sourceList; // some list containing custom objects
    Type t = typeof(List<>).MakeGenericType(sourceList[0].GetType());
    IList res = (IList)Activator.CreateInstance(t);
    
    foreach(var item in sourceList)
    {
        res.Add(item);
    }
