    public static Action PropertyAssign(object sourceObject, object destObject, 
            PropertyInfo sourceProperty, PropertyInfo destProperty)
    {
        Expression source = Expression.PropertyOrField(
        Expression.Constant(sourceObject), sourceProperty.Name);
        Expression dest = Expression.PropertyOrField(
            Expression.Constant(destObject), destProperty.Name);
        Expression assign = Expression.Assign(dest, source);
        return Expression.Lambda<Action>(assign).Compile();
    }
