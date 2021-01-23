    public static List<T> GetClassList() where T:BaseClass
    {
        Dictionary<string, string> s = GetSomeResults<T>();
        List<T> _s = new List<T>();
        foreach (var item in s)
        {
            T c = new T();
            c.Id = item.Key;
            c.Value = item.Value;
            _s.Add(c);
        }
        return _s;
    }
