    public IEnumerable<ProductEnableInfo> GetProducts()
    {
        return db.Products.Select(
            x => new ProductEnableInfo
            {
                ProductName = x.ProductName,
                IsEnabled = x.ProductDetail.IsEnabled
            })
            .ToList();
    }
