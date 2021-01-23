    public static IEnumerable<T> RemoveContiguousDuplicates<T>(this IEnumerable<T> items) where T: IEquatable<T>
    {
        bool init = false;
        T prev = default(T);
        foreach (T item in items)
        {
            if (!init)
                init = true;
            else if (prev.Equals(item))
                continue;
            prev = item;
            yield return item;
        }
    }
