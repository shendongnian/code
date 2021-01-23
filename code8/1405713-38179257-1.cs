    static IEnumerable<T> Order<T, V>(IEnumerable<T> query, string sortOrder, 
                                        Func<T, V> fieldSelector)
    {
        string methodName = sortOrder == "DESC" ? "OrderByDescending" : "OrderBy";
        MethodInfo method = typeof(Enumerable).GetMethods()
                                              .Where(x => x.Name.Contains(methodName))
                                              .FirstOrDefault();
    
        MethodInfo genericMethod = method.MakeGenericMethod(typeof(Resource), typeof(V));
    
        var orderedResults = (IEnumerable<T>)genericMethod.Invoke(null, 
                                        new object[] { query, fieldSelector });
    
        return orderedResults;
    }
