    public interface IProductsRepository {
        ProductEntity AddProduct(ProductEntity product);
    }
    public ProductsRepository: UnitOfWork, IProductsRepository {
        public ProductsRepository(DbContext context) : base(context) { }
        public ProductEntity AddProduct(ProductEntity product) {
            // Don't forget to check here. Only do that where you're using it.
            if (product == null) {
                throw new ArgumentNullException(nameof(product));
            }
            var newProduct = // Implementation...
            if (newProduct != null) {
                Commit();
            }
            return newProduct;
        }
    }
