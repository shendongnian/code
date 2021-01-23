    public static class EntityExtensions
    {
        public static TEntity Select<TEntity>(this IQueryable<TEntity> source, int id) where TEntity : IEntity
        {
            return source.Single(x => x.Id == id);
        }
    }
