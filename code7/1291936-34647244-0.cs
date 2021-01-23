    public static class BaseServiceExtension
    {
        public static IQueryable<TEntity> GetActive<TEntity, TKey>(this IBaseService<TEntity, TKey> service) 
            where TEntity : class, IEntity<TKey>, IActivable
        {
            return service.Get().Where(q => q.Active);
        }
    }
