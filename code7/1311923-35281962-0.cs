    public List<List<T>> Clone(List<List<T>> original)
    {
        var result = new List<List<T>>();
        foreach ( List<T> innerList in original )
        {
            var innerResult = new List<T>();
            foreach ( T item in innerList )
            {
                var clone = (T)(item.Clone());
                innerResult.Add(clone);
            }
            result.Add(innerResult);
        }
        return result;
    }
