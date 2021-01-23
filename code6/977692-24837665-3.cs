    public List<City> GetAllCity<TKey>(SortDirection order, Expression<Func<City, TKey>> SortExpression)
    {
        //main code omitted for brevity
        if (order == SortDirection.Ascending)
            return obj.OrderBy(SortExpression);
        else
            return obj.OrderByDescending(SortExpression);
    }
