    public static IEnumerable<T> WhereAll(this IEnumerable<T> enumerable, Func<object, bool>[] clauses)
    {
        var result = enumerable;
        foreach(var c in clauses)
        {
            result = result.Where(c);
        }
        return result;
    }
