    interface IDBSetWrapper
    {
        object Add(object entity);
    }
    interface IDBContextWrapper
    {
        ...
        IDBSet Set(Type entityType);
        ...
    }
    class DBContextWrapper : IDBContextWrapper
    {
        private readonly DBContext context;
        public DBContextWrapper()
        {
            context = new DBContext();
        }
        ...
        public IDBSet Set(Type entityType)
        {
            var dbSet = context.Set(entityType);
            return new DBSetWrapper(dbSet);
        }
        ...
    }
