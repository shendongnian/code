    private static IEnumerable<T> GetSpecificTypeList<T>(Dictionary<string, List<object>> objectListDictionary)
    {
        Contract.Requires(objectListDictionary != null);
        var collection = objectListDictionary.SingleOrDefault(q => q.Key.Equals(typeof(T).ToString())).Value;
        foreach (var obj in collection)
        {
            yield return (T) Convert.ChangeType(obj, typeof(T));
        }
    }
