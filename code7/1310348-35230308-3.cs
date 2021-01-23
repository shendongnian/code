    IQueryable<Entity> query = context.Set<Entity>();
    if (filters.FilterByColumnA)
        query = query.Where(e => e.ColumnA > filters.FromColumnA && e.ColumnA < filters.ToColumnA);
    ...
    if (filters.FilterByColumnN)
        query = query.Where(e => e.ColumnN > filters.FromColumnN && e.ColumnN < filters.ToColumnN);
