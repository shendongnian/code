    public class Entity<TEntity, TDomainObject, TRepository>
        where TEntity       : Entity<TEntity, TDomainObject, TRepository>
        where TDomainObject : Entity<TEntity, TDomainObject, TRepository>.BaseDomainObject, new()
        where TRepository   : Entity<TEntity, TDomainObject, TRepository>.IBaseRepository
    {
        public class BaseDomainObject {}
        public interface IBaseRepository
        {
            IEnumerable<TDomainObject> GetAll();
        }
        public class BaseRepository : IBaseRepository
        {
            public IEnumerable<SourceAResult> GetAll()
            {
                return new List<TDomainObject>();
            }
        }
    }
