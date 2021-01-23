    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public interface IProductRepository
    {
        List<Product> LoadProducts();
    }
    public class ProductRepository : IProductRepository
    {
        public List<Product> LoadProducts()
        {
            // database code which returns the list of product
            return new List<Product>();
        }
    }
    public class StorageStatisticsGenerator
    {
        private readonly IProductRepository _repository;
        public StorageStatisticsGenerator(IProductRepository repository)
        {
            _repository = repository;
        }
        public int ComputeNumberOfProducts()
        {
            var products = _repository.LoadProducts();
            return products.Count;
        }
    }
