    public static class DbSetExtensions
    {
		public static EntityEntry<TEnt> AddIfNotExists<TEnt, TKey>(this DbSet<TEnt> dbSet, TEnt entity, Func<TEnt, TKey> predicate) where TEnt : class
		{
            var exists = dbSet.Any(c => predicate(entity).Equals(predicate(c)));
            return exists
                ? null
                : dbSet.Add(entity);
		}
		public static void AddRangeIfNotExists<TEnt, TKey>(this DbSet<TEnt> dbSet, IEnumerable<TEnt> entities, Func<TEnt, TKey> predicate) where TEnt : class
        {
            var entitiesExist = from ent in dbSet
                where entities.Any(add => predicate(ent).Equals(predicate(add)))
                select ent;
            dbSet.AddRange(entities.Except(entitiesExist));
        }
	}
