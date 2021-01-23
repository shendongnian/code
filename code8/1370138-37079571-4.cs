    // this contains repositories for all types mapped to used tables
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Table1> Table1Repository { get; private set; }
        public IRepository<Table2> Table2Repository { get; private set; }
        // other come here
        // all these are injected
        public UnitOfWork(IDbContext context, IRepository<Table1> table1Repository, IRepository<Table2> table2Repository
        {
            Table1Repository = table1Repository;
            Table2Repository = table2Repository;
            // other initializations
        }
        // typed version
        public IRepository<T> GetRepository<T>()
            where T: class
        {
            Type thisType = this.GetType();
            foreach (var prop in thisType.GetProperties())
            {
                var propType = prop.PropertyType;
                if (!typeof(IRepository).IsAssignableFrom(propType))
                    continue;
                var repoType = propType.GenericTypeArguments[0];
                if (repoType == typeof(T))
                    return (IRepository<T>) prop.GetValue(this);
            }
            throw new ArgumentException(String.Format("No repository of type {0} found", typeof(T).FullName));
        }
        // dynamic type version (not tested, just written here)
        public IRepository GetRepository(Type type)
            where T: class
        {
            Type thisType = this.GetType();
            foreach (var prop in thisType.GetProperties())
            {
                var propType = prop.PropertyType;
                if (!typeof(IRepository).IsAssignableFrom(propType))
                    continue;
                var repoType = propType.GenericTypeArguments[0];
                if (repoType == type)
                    return (IRepository) prop.GetValue(this);
            }
            throw new ArgumentException(String.Format("No repository of type {0} found", typeof(T).FullName));
        }
    }
