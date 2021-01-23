    public IEnumerable<Product> GetProducts()
    {
        IEnumerable<Product> products =
            db.Products.Include(x => x.ProductDetail).ToList();
    
        return products;
    }
