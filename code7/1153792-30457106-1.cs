    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected Table<T> DataTable;
 
        public Repository(DataContext dataContext)
        {
            DataTable = dataContext.GetTable<T>();
        }
        ...
