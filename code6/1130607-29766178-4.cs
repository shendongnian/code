    public static T GetNext<T>(this IOrderedQueryable<T> list, 
                              T current, 
                              Func<T, object> orderProperty)
    {
        ..
        var propValue = orderProperty(current);
        ..
    }
