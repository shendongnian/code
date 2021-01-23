    private static ICollection<T> GetSpecificTypeList<T>(Dictionary<string, List<object>> objectListDictionary)
    {
        Contract.Requires(objectListDictionary != null);
        Contract.Requires(specificType != null);
    
        var typeFullName = typeof(T).FullName;
        //var collection = objectListDictionary.SingleOrDefault(q => q.Key.Equals(typeFullName)).Value;
        var collection = objectListDictionary[typeFullName];
        var typedCollection = collection.OfType<T>().ToList();
    
        return typedCollection;
    }
