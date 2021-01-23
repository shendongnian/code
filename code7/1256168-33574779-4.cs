    public IEnumerable<ProductEnableInfo> GetProducts(int product_id)
    {
        return db.Products
            .Where(x => x.ProductID == product_id)
            .Select(
            x => new ProductEnableInfo
            {
                ProductName = x.ProductName,
                IsEnabled = x.ProductDetail.IsEnabled
            })
            .ToList();
    }
