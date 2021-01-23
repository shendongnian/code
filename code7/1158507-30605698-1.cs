    public static IEnumerable<T> log_elements<T>(this IEnumerable<T> collection, bool recursive = true)
    {
       logElementsInternal(collection, recursive);
       return collection;
    }
    private static void logElementsInternal(IEnumerable collection, bool recursive)
    {
        Form1.log("[");
        foreach (var i in collection)
            if(recursive && i is IEnumerable)
                logElementsInternal((IEnumerable)i);
            else
                Form1.log(i);
        Form1.log("]");
    }
