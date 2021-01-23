    public interface IRepository<T>
    {
        IQueryable<T> Query {get;}
        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
    public interface IUserRepository : IRepository<IUser>;
    public interface IProductRepository : IRepository<IProduct>;
    public interface IOrderRepository : IRepository<IOrder>;
