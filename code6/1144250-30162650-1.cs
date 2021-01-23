    public int GetId(object obj)
    {
        var anon = new { Id = 0, Name = string.Empty };
        var obj2 = MakeSameType(obj, anon);
        return obj2.Id;
    }
    public static T MakeSameType<T>(object obj, T anonymous)
    {
        return (T)obj;
    }
