    public static Action PropertyAssign(object sourceObject, object destObject, 
            PropertyInfo sourceProperty, PropertyInfo destProperty)
    {
        Expression source = Expression.Property(
        Expression.Constant(sourceObject), sourceProperty);
        Expression dest = Expression.Property(
            Expression.Constant(destObject), destProperty);
        Expression assign = Expression.Assign(dest, source);
        return Expression.Lambda<Action>(assign).Compile();
    }
