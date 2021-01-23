        public interface IRepository<TEntity, in TKey> where TEntity : class
        {
            TEntity Get(TKey id);
            void Save(TEntity entity);
            void Delete(TEntity entity);
        }
