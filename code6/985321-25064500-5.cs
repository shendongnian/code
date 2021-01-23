    public object GetAllProduct()
    {
        var products= _productRepository.GetAllProduct();
        return new { data = products };
    }
