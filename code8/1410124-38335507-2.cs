	// Slight change to BaseRepository, see comments
	public class BaseRepository<T> : BaseRepositoryInterface<T> where T : class {
		private readonly DbContext _ctx; // replaced with DbContext as there is no need to have a strong reference to MyEntities, keep it generic as possible unless there is a good reason not to
		private readonly DbSet<T> _dbSet;
		// replaced with DbContext as there is no need to have a strong reference to MyEntities, keep it generic as possible unless there is a good reason not to
		public BaseRepository(DbContext ctx) {
			_ctx = ctx;
			_dbSet = _ctx.Set<T>();
		}
		public IEnumerable<T> GetAll() {
			return _dbSet;
		}
		//...
	}
