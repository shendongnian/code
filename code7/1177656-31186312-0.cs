    public static class DbSetExtensions
    {
        public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity,
            Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            T exists = predicate != null ?
                dbSet.Where(predicate).FirstOrDefault():
                dbSet.FirstOrDefault();
            return exists == null ?
                dbSet.Add(entity):
                exists;
        }
    }
