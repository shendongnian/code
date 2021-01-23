    private static T? SafeGetStruct<T>(IList<T> list, int index) where T : struct 
    {
        if (list == null || index < 0 || index >= list.Count)
        {
            return null;
        }
    
        return list[index];
    }
    
    public static T SafeGet<T>(IList<T> list, int index) where T : class
    {
        if (list == null || index < 0 || index >= list.Count)
        {
            return null;
        }
    
        return list[index];
    }
    public static int? SafeGet(IList<int> list, int index)
    {
        return SafeGetStruct(list, index);
    }
    public static long? SafeGet(IList<long> list, int index)
    {
        return SafeGetStruct(list, index);
    }
    etc...
