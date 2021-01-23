    [TestMethod]
    public void DeletionShouldBeSentToRepository() //RN03
    {
        var product = new Product() { Id = 1, Name = "aaaaaa", Code = "aaaaaa", FlgActive = true };
        var so = new ServiceOrder() {  };
        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(p => p.Delete(product));
        var mockServiceOrderRepository = new Mock<IServiceOrderRepository>();
        mockServiceOrderRepository.Setup(o => o.GetProductById(product.Id)).Returns(new List<ServiceOrder> { so });
        var service = new ProductService(mockProductRepository.Object, mockServiceOrderRepository.Object);
        service.Delete(product);
        mockProductRepository.Verify(c => c.Delete(product), Times.Once());
        mockProductRepository.Verify((s => s.Commit()), Times.Once());
    }
