    public delegate void Assign(TSource sourceObject, TDest destObject);
    public static Assign PropertyAssign(TSource sourceObject, TDestdestObject, 
            PropertyInfo sourceProperty, PropertyInfo destProperty)
    {
        var sourceObjectExpression = Expression.Parameter(sourceObject);
        var destPropertyExpression = Expression.Parameter(destProperty);
        Expression source = Expression.Property(
                     sourceObjectExpression, sourceProperty);
        Expression dest = Expression.Property(
            destPropertyExpression, destProperty);
        Expression assign = Expression.Assign(dest, source);
        var lambda = Expression.Lambda<Assign>(
              assign, sourceObjectExpression, destPropertyExpression);
        return lambda.Compile();
    }
