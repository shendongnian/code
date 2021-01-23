    var queryable = dbContext.EntityMasters.OfType<Person>();
    if (includeFiles)
    {
        queryable = queryable.Include(p => p.FileMasters);
    }
