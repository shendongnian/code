    //Given a custom context object such that CustomContext inherits from DbContext AND contains an arbitrary number of DbSet collections
    //which represent the data in the database (i.e. DbSet<MyObject>), this method fetches a queryable collection of object type T which
    //will preload sub-objects specified by the array of expressions (includeExpressions) in the form o => o.SubObject.
    public static IQueryable<T> GetQueryable<T>(this CustomContext context, params Expression<Func<T, object>>[] includeExpressions) where T : class
    {
        //look through the context for a dbset of the specified type
        var property = typeof(CustomContext).GetProperties().Where(p => p.PropertyType.IsGenericType &&
                                                                        p.PropertyType.GetGenericArguments()[0] == typeof(T)).FirstOrDefault();
        //if the property wasn't found, we don't have the queryable object. Throw exception
        if (property == null) throw new Exception("No queryable context object found for Type " + typeof(T).Name);
        //create a result of that type, then assign it to the dataset
        IQueryable<T> source = (IQueryable<T>)property.GetValue(context);
        //return 
        return includeExpressions.Aggregate(source, (current, expression) => current.Include(expression));
    }
