    public interface IRepository<T>    
    {        
        T GetById(int sourceid, int id);
    }
    
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public TEntity GetById(int sourceId, int id)
        {
            return _dbContext.Set<TEntity>().Find(sourceId, id);
        }
    }
