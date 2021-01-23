    public static Dictionary<string, object> GetPropertyValuePairs(this object obj, String[] hidden = null)
    {
        var type = obj.GetType();
        var pairs = hidden == null
            ? type.GetProperties()
                .DistinctBy(propertyInfo => propertyInfo.Name)
                .ToDictionary(
                    propertyInfo => propertyInfo.Name,
                    propertyInfo => propertyInfo.GetValue(obj, null))
            : type.GetProperties()
                .Where(it => !hidden.Contains(it.Name))
                .DistinctBy(propertyInfo => propertyInfo.Name)
                .ToDictionary(
                    propertyInfo => propertyInfo.Name,
                    propertyInfo => propertyInfo.GetValue(obj, null));
        return pairs;
    }
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        var seenKeys = new HashSet<TKey>();
        return source.Where(element => seenKeys.Add(keySelector(element)));
    }
