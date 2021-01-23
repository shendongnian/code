    public static void Foo<T>(ICollection<T> dest)
    {
        IEnumerable<T> items = ... 
        List<T> list = dest as List<T>;
        if (list != null)
            list.AddRange(items);
        else
        {
            foreach (T item in items)
                dest.Add(item);
        }
    }
