    /// <summary>
    /// Returns the top level items including all their recursive descendants.
    /// </summary>
    /// <typeparam name="T">The generic enumerable type parameter.</typeparam>
    /// <param name="source">The source to traverse.</param>
    /// <param name="childPropertyExpression">The recursive property expression.</param>
    /// <returns>IEnumerable(<typeparamref name="T"/>)</returns>
    internal static IEnumerable<T> IncludeDescendants<T>(this IEnumerable<T> source, Expression<Func<T, IEnumerable<T>>> childPropertyExpression)
    {
        // The actual recursion is processed inside the private static method
        // This method is serving the purpose of writing expressions.
        var items = IncludeDescendants(source, childPropertyExpression.Compile());
        foreach (var item in items)
        {
            yield return item;
        }
    }
    
    private static IEnumerable<T> IncludeDescendants<T>(IEnumerable<T> source, Func<T, IEnumerable<T>> childPropertyFunc)
    {
        foreach (var item in source)
        {
            yield return item;
            var subSource = childPropertyFunc.Invoke(item);
            if (subSource != null)
            {
                foreach (var subItem in IncludeDescendants(subSource, childPropertyFunc))
                {
                    yield return subItem;
                }
            }
        }
    }
