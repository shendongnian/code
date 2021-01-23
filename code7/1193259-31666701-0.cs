    public static IQueryable<T> Select(this IQueryable<T> list, string field)
    {
        // Create an Expression and find the property field
        ParameterExpression pe = Expression.Parameter(typeof(string), field);
        // Apply the Expression to the IQueryable
    }
