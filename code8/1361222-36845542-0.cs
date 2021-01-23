    var dbSet = context.Set<MyObject>();
    var clone = dbSet.Include(e => e.Property1)
                     .Include(e => e.Property2)
                     .Include(e => e.Property3)
                     .AsNoTracking()
                     .First(e => e.Id == OriginalPrimaryKey);
    clone.Property1.Id = 0;
    clone.Property2.Id = 0;
    clone.Property3.Id = 0;
    dbSet.Add(clone);
    context.SaveChanges();
