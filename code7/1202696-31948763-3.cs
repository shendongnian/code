    using System.Linq.Expressions;
    public static Expression<Func<T, object>> GetPropertySelector<T>(string propertyName)
    {
        var arg = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(arg, propertyName);
        //return the property as object
        var conv = Expression.Convert(property, typeof(object));
        var exp = Expression.Lambda<Func<T, object>>(conv, new ParameterExpression[] { arg });
        return exp;
    }
