    public static IEnumerable<T> Skip<T>(IEnumerable<T> set, int count)
    {
        if(set == null) throw ArgumentNullException("set");
        if(count < 0) throw ArgumentOutOfRangeException("count");
        return SkipImp(set, count);
    }
    private static IEnumerable<T> SkipImp<T>(IEnumerable<T> set, int count)
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
        if(set == null) throw ArgumentNullException("set");
        if(count < 0) throw ArgumentOutOfRangeException("count");
        return TakeImp(set, count);
    }
    private static IEnumerable<T> TakeImp<T>(IEnumerable<T> set, int count)
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
