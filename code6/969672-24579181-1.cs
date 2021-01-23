    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
    public class EntityFrameworkRepository<TEntity> : IEntity<TEntity>
    {
        private readonly DbContext context;
        public EntityFrameworkRepository(DbContext context) {
            this.context = context;
        }
        public IQueryable<TEntity> GetAll() {
            return this.context.Set<TEntity>();
        }
        public TEntity GetById(Guid id) {
            var item = this.context.Set<TEntity>().Find(id);
            if (item == null) throw new KeyNotFoundException(id.ToString());
            return item;
        }
    }
