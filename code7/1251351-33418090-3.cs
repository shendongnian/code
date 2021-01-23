    public static IDictionary<string, List<T>> Classify<T>(this IEnumerable<T> items, IDictionary<string, Predicate<T>> predicates, out List<T> defaultBucket)
    {
        var classifiedItems = new Dictionary<string, List<T>>(predicates.Count);
        defaultBucket = new List<T>();
        foreach (var predicate in predicates)
        {
            classifiedItems.Add(predicate.Key, new List<T>()); 
        }
        foreach (var item in items)
        {
            var matched = false;
            foreach (var predicate in predicates)
            {
                if (predicate.Value(item))
                {
                    matched = true;
                    classifiedItems[predicate.Key].Add(item);
                    break;
                }
            }
            if (!matched)
            {
                defaultBucket.Add(item);
            }
        }
        return classifiedItems;
    }
