    public IEnumerable<Product> GetAllProdcut()
    {
        var products= _productRepository.GetAllProduct();
        return new { data = products };
    }
