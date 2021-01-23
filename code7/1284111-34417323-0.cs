    public class DbSetWithFind<TEntity> : DbSet<TEntity> where TEntity : class
    {
        private readonly IQueryable<TEntity> _dataSource;
        public DbSetWithFind(IQueryable<TEntity> dataSource)
        {
            _dataSource = dataSource;
        }
        public sealed override TEntity Find(params object[] keyValues) // sealed override prevents EF from "ruining" it.
        {
            var keyProperties = typeof (TEntity).GetProperties()
                .Where(property => property.IsDefined(typeof (KeyAttribute), true));
            return _dataSource.SingleOrDefault(entity =>
                keyProperties
                    .Select(property => property.GetValue(entity))
                    .Intersect(keyValues)
                    .Any());
        }
    }
