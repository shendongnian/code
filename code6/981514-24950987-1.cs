    public static List<T> GetClass<T>() where T : IClass, new()
    {
        Dictionary<string, string> s = GetSomeResults2();
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
