    public static class DbSetExtensions
    {
        private static Dictionary<Type, PropertyInfo> keys = new Dictionary<Type, PropertyInfo>();
        public static T Upsert<T>(this DbSet<T> set, T entity)
            where T : class
        {
            DbContext db = set.GetContext();            
            Type entityType = typeof(T);
            PropertyInfo keyProperty;
            if (!keys.TryGetValue(entityType, out keyProperty))
            {
                keyProperty = entityType.GetProperty(GetKeyName<T>(db));
                keys.Add(entityType, keyProperty);
            }
            T entityFromDb = set.Find(keyProperty.GetValue(entity));
            if (entityFromDb == null)
                return set.Add(entity);
            db.Entry(entityFromDb).State = EntityState.Detached;
            db.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        // other methods explained below
    }
