    public interface IMyUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }
        IRepository<Product> Products { get; }
        IRepository<Orders> Orders { get; }
        ...
    }
