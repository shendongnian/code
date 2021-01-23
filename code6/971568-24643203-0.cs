    public IEnumerable<T> GetOfType<T>(IEnumerable<object> list)
    {
        return list.OfType<T>();
    }
    public IEnumerable<object> GetOfType(IEnumerable<object> list, Type type)
    {
        return list.All(obj => obj != null && obj.GetType() == type);
    }
