    private static IQueryable<T> GetToday<T>(this IQueryable<T> source)
        where T : IHazDateAdded
    {
        DateTime start = DateTime.Today, end = start.AddDays(1);
        return source.Where(p => p.DateAdded >= start && p.DateAdded < end);
    }
