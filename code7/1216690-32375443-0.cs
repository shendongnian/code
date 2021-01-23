    public static bool HasDuplicates<T>(this IEnumerable<T> list)
    {
        HashSet<T> distinct = new HashSet<T>();
        foreach (var s in list)
        {
            if (!distinct.Add(s))
            {
                return true;
            }
        }
        return false;
    }
