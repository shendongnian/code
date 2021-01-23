    public static T AnyOne<T>(this IEnumerable<T> source)
    {
        var list = source as IReadOnlyList<T>;
        if (list != null)
        {
            int index = Random.Range(0, list.Count);
            return list[index];
        }
        var list2 = source as IList<T>;
        if (list2 != null)
        {
            int index = Random.Range(0, list2.Count);
            return list2[index];
        }
        else
        {
            double count = 1;
            T result = default(T);
            foreach (var element in source)
            {
                if (Random.NextDouble() <= (1.0 / chance)) 
                {
                    result = element;
                }
                ++count;
            }
            return result;
        }
    }
