    public class ProductsManager : IProductsManager
    {
        private readonly Func<Owned<IProductsManagerProvider>> _managerProvider;
        //Now we don't hide any dependencies.
        public ProductsManager(Func<Owned<IProductsManagerProvider>> managerProvider)
        {
            _managerProvider = managerProvider;
        }
    
        public bool AddProduct(ProductEntity product)
        {
            using (var provider = _managerProvider())
            {
                return provider.Value.AddProduct(product);
            }
        }
    }
