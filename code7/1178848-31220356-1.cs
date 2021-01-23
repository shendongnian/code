    public static IQueryable<Log> TakeFirst50OrderDateDesc(this IQueryable<Log> top50)
    {
        return top50.OrderByDescending(o => o.Date)
        .Take(50);
        
    }
