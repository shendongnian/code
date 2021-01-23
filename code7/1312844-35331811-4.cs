    // inside a generic class.
    public static IQueryable<T> GetWhere(string criteria1, string criteria2, string criteria3, string criteria4)
    {
        var t = MyExpressions<T>.DynamicWhereExp(criteria1, criteria2, criteria3, criteria4);
        return db.Set<T>().Where(t);
    }
 
