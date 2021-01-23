    public class MyContext : DbContext
    {
        private readonly Dictionary<Type, Func<object>> _dbSets;
        public MyContext() : base(nameOrConString) {
            _dbSets = new Dictionary<Type, Func<object>> {
                {typeof (A), () => base.Set<A>()},
                {typeof (B), () => base.Set<B>()}
            };
        }
        public override DbSet<TEntity> Set<TEntity>() {
            if (!_dbSets.Contains(typeof (TEntity)))
                return null; // or throw exception or whatever
            return _dbSets[typeof (TEntity)]() as DbSet<TEntity>;
        }
    }
