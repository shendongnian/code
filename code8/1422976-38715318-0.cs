    public class DatabaseEntities : DbContext
    {
        public object GetList(string entityName)
        {
            return GetList(Type.GetType(entityName));
        }
        private List<TEntity> GetList<TEntity>(TEntity type) where TEntity : class
        {
            return Set<TEntity>().ToList();
        }
    }
