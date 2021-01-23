    [TestMethod]
    public void DeletedProductFlagShouldBeFalse() //RN03
    {
        var product = new Product() { Id = 1, Name = "aaaaaa", Code = "aaaaaa", FlgActive = true };
        
        IProductRepository repository = new ProductRepository();
        repository.Delete(product);
        Assert.IsFalse(product.FlgActive);
    }
