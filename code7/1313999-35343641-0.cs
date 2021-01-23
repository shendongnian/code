    public static Expression<Func<TObject, TPropertyType>> Generate<TObject, TPropertyType>(
        string property_name)
    {
        var parameter = Expression.Parameter(typeof (TObject));
        return Expression.Lambda<Func<TObject, TPropertyType>>(
            Expression.Property(parameter, property_name), parameter);
    }
