    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> source)
    {
        var asList = collection as List<T>;
        if (asList != null)
        {
            asList.AddRange(source);
        }
        else
        {
            foreach (T item in source)
            {
                collection.Add(item);
            }
        }
    }
