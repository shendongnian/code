    public static List<T> GetListCacheMock<T>() where T : IModel, new()
    {
        var list = new List<T>();
    
        list.Add(new T { Code = "S1", Description = "Test 1" });
        list.Add(new T { Code = "S2", Description = "Test 2" });
        list.Add(new T { Code = "S2", Description = "Test 3" });
    
        return list;
    }
