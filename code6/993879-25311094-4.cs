    public static IEnumerable<IEnumerable<T>> Paginate<T>(
        this IQueryable<T> query,
        int pageSize)
    {
        int page = 0;
        while (true)
        {
            var nextPage = query.Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
            if (nextPage.Any())
                yield return nextPage;
            else
                yield break;
            page++;
        }
    }
