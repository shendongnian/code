    public abstract class Entity<TEntity, TDomainObject, TIRepository>
        where TEntity       : Entity<TEntity, TDomainObject, TIRepository>
        where TDomainObject : Entity<TEntity, TDomainObject, TIRepository>.BaseDomainObject, new()
        where TIRepository  : Entity<TEntity, TDomainObject, TIRepository>.IBaseRepository
    {
        public class BaseDomainObject {}
        public interface IBaseRepository
        {
            IEnumerable<TDomainObject> GetAll();
            IEnumerable<T> GetAllMapped<T>(Func<TDomainObject, T> mapper);
        }
        public class BaseRepository : IBaseRepository
        {
            public IEnumerable<TDomainObject> GetAll()
            {
                return new List<TDomainObject>();
            }
            public IEnumerable<T> GetAllMapped<T>(Func<TDomainObject, T> mapper)
            {
                return this.GetAll().Select(mapper);
            }
        }
    }
