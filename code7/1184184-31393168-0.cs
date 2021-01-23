    private IEnumerable<T> Sort<T> (List<T> list, string propertyName)
    {
        MethodInfo orderByMethod = typeof(Enumerable).GetMethods().First(mi => mi.Name == "OrderBy" && mi.GetParameters().Length == 2);
    
        PropertyInfo pi = typeof(T).GetProperty(propertyName);
        MethodInfo orderBy = orderByMethod.MakeGenericMethod(typeof(T), pi.PropertyType);
        
        ParameterExpression param = Expression.Parameter(typeof(T));
        Delegate accessor = Expression.Lambda(Expression.Call(param, pi.GetGetMethod()), param).Compile();
        return (IEnumerable<T>)orderBy.Invoke(null, new object[] { lst, accessor });
    }
