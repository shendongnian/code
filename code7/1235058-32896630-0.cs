    private static ICollection<T> GetSpecificTypeList<T>(Dictionary<string, List<object>> objectListDictionary)
    {
        Contract.Requires(objectListDictionary != null);
        Contract.Requires(specificType != null);
    
        var typeFullName = typeof(T).FullName;
        var collection = objectListDictionary.SingleOrDefault(q => q.Key.Equals(typeFullName)).Value;
        var typedCollection = collection.OfType<T>();
    
        return typedCollection;
    }
