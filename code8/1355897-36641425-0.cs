    public delegate void MyDelegate(ref IQueryable<object> query, Expression<Func<object, object>> lambda);
    private MyDelegate Create()
    {
        return delegate(ref IQueryable<object> query, Expression<Func<object, object>> lambda)
        {
            query = query.OrderBy(lambda);
        };
    }
