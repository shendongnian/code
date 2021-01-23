    public static List<T> GetListCacheMock<T>(Func<T> getNew) where T : IModel
    {
        var list = new List<T>();
        
        var item1 = getNew();
        item1.Code = "S1";
        item1.Description = "Test 1";
        list.Add(item1);
        ...
    
        return list;
    }
