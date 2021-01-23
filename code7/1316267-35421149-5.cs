    public GetQuery(string field, string value)
    {
        var query = context.Orders;
        var condition = MakeSimplePredicate<Order>(field, ExpressionType.Equal, value);
        return query.Where(condition);
    }
