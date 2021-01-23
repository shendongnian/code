    public static IEnumerable<GroupResult> GroupByMany<TElement>(
           this IEnumerable<TElement> elements, params string[] groupSelectors)
    {
        var selectors =
            new List<Func<TElement, object>>(groupSelectors.Length);
        foreach (var selector in groupSelectors)
        {
            LambdaExpression l =
                DynamicExpression.ParseLambda(
                    typeof(TElement), typeof(object), selector);
            selectors.Add((Func<TElement, object>)l.Compile());
        }
        return elements.GroupByMany(selectors.ToArray());
    }
    public static IEnumerable<GroupResult> GroupByMany<TElement>(
        this IEnumerable<TElement> elements,
        params Func<TElement, object>[] groupSelectors)
    {
        if (groupSelectors.Length > 0)
        {
            var selector = groupSelectors.First();
            //reduce the list recursively until zero
            var nextSelectors = groupSelectors.Skip(1).ToArray();
            return
                elements.GroupBy(selector).Select(
                    g => new GroupResult
                    {
                        Key = g.Key,
                        Count = g.Count(),
                        Items = g,
                        SubGroups = g.GroupByMany(nextSelectors)
                    });
        }
        else
            return null;
    }
