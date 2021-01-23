    public interface IProductsDataService : IDisposable {
        ProductEntity AddProduct(ProductEntity product);
    }
    public class ProductsDataService : IProductsDataService {
        private IProductsRepository _repository;
        public ProductsDataService(IProductsRepository repository) {
            _repository = repository;
        }
        public ProductEntity AddProduct(ProductEntity product) {
            return _repository.AddProduct(product);
        }
        public bool Dispose() {
            _repository.Dispose();
        }
    }
