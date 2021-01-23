    public static IEnumerable<T> Skip<T>(IEnumerable<T> set, int count)
    {
        foreach(var item in set)
        {
            if(count-- <= 0)
            {
                yield return item;
            }
        }
    }
    public static IEnumerable<T> Take<T>(IEnumerable<T> set, int count)
    {
        foreach(var item in set)
        {
            if(count-- > 0)
            {
                yield return item;
            }
            else
            {
                yield break;
            }
        }
    }
