    public static List<T> EnsureSize<T>(this List<T> list, int size, Func<T> generator)
    {
        if (list == null) throw new ArgumentNullException("list");
        if (size < 0) throw new ArgumentOutOfRangeException("size");
    
        int count = list.Count;
        if (count < size)
        {
            int capacity = list.Capacity;
            if (capacity < size)
                list.Capacity = Math.Max(size, capacity * 2);
    
            while (count < size)
            {
                list.Add(generator());
                ++count;
            }
        }
    
        return list;
    }
