    public static IList<T> CastToList<T>(this IEnumerable source)
    {
        return new List<T>(source.Cast<T>());
    }
    var finalQuery = query.Select(string.Format("new({0})",
                                                string.Join(",", selectors)));
    var result = finalQuery.CastToList<dynamic>();
