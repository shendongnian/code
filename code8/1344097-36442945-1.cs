     public interface IRepository<TEntity> where TEntity : class
    {
	   	TEntity Find(Expression<Func<TEntity, bool>> match);
    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext Context { get; set; }
        public Repository(DbContext context)
        {
           this.Context = context;
        }
		public TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return Context.Set<TEntity>().SingleOrDefault(match);
        }
	}
