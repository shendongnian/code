    public static List<ProductDto> GetProducts()
    {
        using (var dbcontext = new EnterpriseEntities())
        {
             var _products = dbcontext.Products.
                            Select(x=> new ProductDto
                               {  Id =x.Id, 
                                  Name =x.Name,
                                  Types= x.TypeProducts
                                           .Select(t=>new TypeProductDto
                                                      { Name =x.Name})
                               }).ToList();
             return _products;
        }
    }
