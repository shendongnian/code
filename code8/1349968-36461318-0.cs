    private static Expression<Func<Books, bool>> GenerateListContainsLikeExpression(string propertyName, List<string> values)
    {
        var parameter = Expression.Parameter(typeof(Books), "b");
        var listParameter = Expression.Parameter(typeof(string), "v");
        var property = Expression.Property(parameter, propertyName);
        var anyMethod = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public).First(m => m.Name == "Any" && m.GetParameters().Count() == 2).MakeGenericMethod(typeof(string));
        var toStringMethod = typeof(object).GetMethod("ToString");
        var containsMethod = typeof(string).GetMethod("Contains");
        var objectString = Expression.Call(property, toStringMethod);
        var lambda = Expression.Call(objectString, containsMethod, listParameter);
        var func = Expression.Lambda<Func<string, bool>>(lambda, listParameter);
        var comparison = Expression.Call(anyMethod, Expression.Constant(values), func);
        return Expression.Lambda<Func<Books, bool>>(comparison, parameter);
    }
