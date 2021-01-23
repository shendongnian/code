    static T SafeGet<T>(IList<T> list, int index) where T : class
    {
        if (list == null || index < 0 || index >= list.Count)
        {
            return null;
        }
    
        return list[index];
    }
    static int? SafeGet(IList<int> list, int index)
    {
        if (list == null || index < 0 || index >= list.Count)
        {
            return null;
        }
    
        return list[index];
    }
    static long? SafeGet(IList<long> list, int index)
    {
        if (list == null || index < 0 || index >= list.Count)
        {
            return null;
        }
    
        return list[index];
    }
    etc...
