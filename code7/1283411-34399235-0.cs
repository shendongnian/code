    public static T RemoveAndReturnFirst<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            return default(T);
        }
        T currentFirst = list[0];
        list.RemoveAt(0);
        return currentFirst;
    }
