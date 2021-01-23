    public static IEnumerable GetDistinctValues<T>(IEnumerable<T> gridItems, string propertyName) where T : class
    {
        // logic to return the distinct values for the given property name...
        var xpre = GetPropertyExpression<T>(typeof(T), propertyName);
        return gridItems.GroupBy(item => xpre).Select(item => item.First());
    }
    private static Func<T, object> GetPropertyExpression<T>(Type type, string propertyName)
    {
        ParameterExpression parameter = Expression.Parameter(type, "x");
        MemberExpression propertyExpr = GetPropertyExpression(parameter, type, propertyName);
        if (propertyExpr == null)
            return null;
        Expression<Func<T, object>> expression = Expression.Lambda<Func<T, object>>(Expression.Convert(propertyExpr, typeof(object)), new ParameterExpression[1] { parameter });
        return expression.Compile();
    }
    private static MemberExpression GetPropertyExpression(Expression param, Type type, string propertyName)
    {
        var property = type.GetProperty(propertyName);
        if (property == null)
        {
            if (propertyName.Contains("_") || propertyName.Contains("."))
            {
                var innerProps = propertyName.Split(new char[] { '_', '.' }, 2);
                property = type.GetProperty(innerProps[0]);
                if (property != null)
                {
                    var pe = Expression.Property(param, property);
                    return GetPropertyExpression(pe, property.PropertyType, innerProps[1]);
                }
                else
                {
                    return null;
                }
            }
        }
        else
        {
            return Expression.Property(param, property);
        }
        return param as MemberExpression;
    }
