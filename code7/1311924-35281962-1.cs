    public static List<List<T>> Clone<T>(List<List<T>> original)
        where T : ICloneable
    {
        var result = new List<List<T>>();
        foreach ( List<T> innerList in original )
        {
            var innerResult = new List<T>();
            foreach ( T item in innerList )
            {
                var clone = (T)item.Clone();
                innerResult.Add(clone);
            }
            result.Add(innerResult);
        }
        return result;
    }
