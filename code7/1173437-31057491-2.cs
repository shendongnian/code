    public static IEnumerable<Dictionary<object, object>> Sort(
        this IEnumerable<Dictionary<object, object>> data,
        IEnumerable<OrderClause> orderClauseList)
    {
        var ordered = data.OrderBy(_ => 1);
        return orderClauseList.Aggregate(ordered, (current, orderClause) =>
            (orderClause.IsAscending)
            ? current.ThenBy(d => d[orderClause.ColumnName])
            : current.ThenByDescending(d => d[orderClause.ColumnName]));
    }
