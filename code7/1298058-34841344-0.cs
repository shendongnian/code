    public static T GetRandom<T>(this IEnumerable<T> collection)
    {
        if(collection == null)
            throw new ArgumentNullException("collection");
        //...
    }
