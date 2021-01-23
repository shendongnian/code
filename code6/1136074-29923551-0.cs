    public IEnumerable<T> Filter(Func<T, object> getProperty, IEnumerable<T> coll,
        object value)
    {
        return coll
            .Where(x => getProp(x).Equals(value));
    }
    
