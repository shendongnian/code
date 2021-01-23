    public static void AddIfNotExists<T>(this DbSet<T> dbSet, Func<T, object> predicate, params T [] entities) where T : class, new()
    {
        foreach (var entity in entities)
        {
            var newValues = predicate.Invoke(entity);
            Expression<Func<T, bool>> compare = arg => predicate(arg).Equals(newValues);
            var compiled = compare.Compile();
            var existing = dbSet.FirstOrDefault(compiled);
            if (existing == null)
            {
                dbSet.Add(entity);
            }
        }
    }
