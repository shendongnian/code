    public class ProductsManager : IProductsManager
        {
            //This is kind of service locator. We hide Uow and ProductDataService dependencies.
            private readonly ILifetimeScope _lifetimeScope;
    
            public ProductsManager(ILifetimeScope lifetimeScope)
            {
                _lifetimeScope = lifetimeScope;
            }
        }
