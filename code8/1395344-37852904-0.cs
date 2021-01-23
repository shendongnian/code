    public static Task<List<ProductItem>> GetAllProducts()
    {
        var context = GetMyContext();
        return context.Products
                      .Select(x => new ProductItem{ //create item})
                      .ToListAsync();
    }
