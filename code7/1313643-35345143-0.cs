    private static Func<TElement, object> CreateSelector<TElement>(string key)
    {
        var parameter = Expression.Parameter(typeof(TElement), "lambdaKey");
        var property = Expression.PropertyOrField(parameter, key);
        var lambda = Expression.Lambda<Func<TElement, string>>(property, parameter);
        return lambda.Compile();
    }
    public static IEnumerable<GroupResult> GroupByMany<TElement>(
        this IEnumerable<TElement> elements,
        params string[] groupKeys)
    {
        return elements.GroupByMany(groupKeys.Select(CreateSelector<TElement>).ToArray());
    }
