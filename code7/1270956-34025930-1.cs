    public static IList<Product> gridDatos()
    {
        using (var dbcontext = new EnterpriseEntities())
        {
             var _products = dbcontext.Products.
                            Include(c => c.TypeProducts).ToList();
             return _products;
        }
    }
 
