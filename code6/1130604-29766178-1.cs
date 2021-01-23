    public static T GetNext<T>(this IOrderedQueryable<T> list, T current, string orderProperty)
    {
        var predicate = string.Format("{0} > @0", orderProperty);
        var propValue = current.GetType()
                               .GetProperty(orderProperty, 
                                            BindingFlags.Public | BindingFlags.Instance)
                               .GetValue(current);
        return (T)list.Where(predicate, propValue).FirstOrDefault();
                      //where comes from System.Linq.Dynamic
    }
