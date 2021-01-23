    private static Expression<Func<Books, bool>> GenerateListContainsExpression(
        string propertyName,
        List<string> values)
    {
        var parameter = Expression.Parameter(typeof(Books), "b");
        var property = Expression.Property(parameter, propertyName);
        var contains_method = typeof(List<string>).GetMethod("Contains");
        var to_string_method = typeof(object).GetMethod("ToString");
        var contains_call = Expression.Call(
            Expression.Constant(values),
            contains_method,
            Expression.Call(property, to_string_method));
        return Expression.Lambda<Func<Books, bool>>(contains_call, parameter);
    }
