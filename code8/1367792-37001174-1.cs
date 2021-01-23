    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> seq)
    {
        List<T> list = collection as List<T>;
        if (list != null)
            list.AddRange(seq);
        else
        {
            foreach (T item in seq)
                collection.Add(item);
        }
    }
// ...
    public static void Foo<T>(ICollection<T> dest)
    {
        IEnumerable<T> items = ... 
        dest.AddRange(items);
    }
