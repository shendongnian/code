    private static ICollection<T> GetSpecificTypeList<T>(Dictionary<string, List<object>> objectListDictionary)
    {
        Contract.Requires(objectListDictionary != null);
        Contract.Requires(specificType != null);
        var list = new List<T>();
        var collection = objectListDictionary.SingleOrDefault(q => q.Key.Equals(typeof(T).FullName)).Value;
        foreach (var obj in collection.OfType<T>())
        {
            list.Add(obj);
        }
        return list;
    }
