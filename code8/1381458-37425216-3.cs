    private static Dictionary<string, object> _LUT;
    
    public static T GetObject<T>(String name, Func<T> creator)
    {
        object obj;
        if (_LUT.TryGetValue(name, out obj))
        {
            return (T)obj;
        }
        T ret = creator();
        _LUT.Add(name, ret);
        return ret;
    }
    public string GetString(string name)
    {
        return GetObject<string>(name, () => "Foo");
    }
