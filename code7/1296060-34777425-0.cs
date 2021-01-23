    public class Repository<TEntity> where TEntity: class, IEntity
    {
        private YourContext context = new YourContext();
        private DbSet<TEntity> AppDbSet;
        public Repository()
        {
            AppDbSet = context.Set<TEntity>();
        }
        //a couple of method to retrieve data...
        public List<TEntity> GetAll()
        {
            return AppDbSet.ToList();
        }
        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return AppDbSet.Where<TEntity>(predicate);
        }
        public TEntity Single(Func<TEntity, bool> predicate)
        {
            return AppDbSet.FirstOrDefault(predicate);
        }
        //Lastly, implement a validation method
        public bool IsValid(TEntity entity)
        {
            if (AppDbSet.SingleOrDefault(x => x.Title == entity.Title) != null)
                return false;
            else
                return true;
        }
    }
