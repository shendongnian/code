    public static List<IModel> Obj2ListCacheMock<IModel>()
    {
        var list = new List<IModel>();
        list.Add(new Obj1() { Code = "S1", Description = "Test 1" });
        list.Add(new Obj2() { Code = "S2", Description = "Test 2" });
        list.Add(new Obj1() { Code = "S2", Description = "Test 3" });
        return list;
    }
