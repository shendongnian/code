    public interface IRepository<T>
    {
        IQueryable<T> All { get; }
        void Update(T entity);
        T Get(int id); //If you have a standard type for IDs
        //etc.
     }
