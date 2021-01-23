    private static Expression<Func<IEnumerable<TItem>, TItem>> GetValidItemForDate<TItem>(
                Expression<Func<TItem, DateTime>> dateSelector, 
                DateTime date)
    {
        return Linq.Expr((IEnumerable<TItem> items) =>
            items.Where(it => dateSelector.Invoke(it) <= date)
                .OrderByDescending(it => dateSelector.Invoke(it))
                .FirstOrDefault())
            .Expand();
    }
