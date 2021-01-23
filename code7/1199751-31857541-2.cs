    public class ProductService : IProductService
    {
       readonly IDbSet<Product> _products;
       [DefaultConstructor]
       public AccountController()
       {
       }
       ...
    }     
