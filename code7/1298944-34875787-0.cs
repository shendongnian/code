    public interface IProductStore
    {
        IEnumerable<Product> All { get; }
    
        IEnumerable<Product> OutOfStock { get; }
    
        Product GetById(Guid Id);
    }
