    public static IEnumerable<dynamic> SomeName (dynamic input)
    {
        var collection = input as IEnumerable<dynamic>;
        if (collection == null)
            return Enumerable.Empty<dynamic>();
        foreach (var item in collection)
        {
            /*recursive part*/
        }
        return collection;
    }
