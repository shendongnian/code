    public static class QueryHelper
    {
        private static readonly MethodInfo OrderByMethod =
            typeof (Queryable).GetMethods().Single(method => 
              method.Name == "OrderBy" && method.GetParameters().Length == 2);
    
        private static readonly MethodInfo OrderByDescendingMethod =
            typeof (Queryable).GetMethods().Single(method => 
              method.Name == "OrderByDescending" && method.GetParameters().Length == 2);
    
        public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> source, 
            SortOrder sortOrder, string propertyName)
        {
            if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | 
                BindingFlags.Public | BindingFlags.Instance) == null)
            {
                return null;
            }
            ParameterExpression paramterExpression = Expression.Parameter(typeof(T));
            Expression orderByProperty = Expression.Property(paramterExpression, propertyName);
            LambdaExpression lambda = Expression.Lambda(orderByProperty, paramterExpression);
            MethodInfo genericMethod = sortOrder == SortOrder.Ascending
                ? OrderByMethod.MakeGenericMethod(typeof (T), orderByProperty.Type)
                : OrderByDescendingMethod.MakeGenericMethod(typeof (T), orderByProperty.Type);
            object ret = genericMethod.Invoke(null, new object[] {source, lambda});
            return (IQueryable<T>) ret;
        }
    }
