    [TestMethod]
    public void ProductService_Given_Product_Id_Should_Get_Product_Name() {
        //Arrange
        var productId = 1;
        var expected = "AAA";
        var product = new Product() { ProductName = expected, ProductID = productId };
        var productRepositoryMock = new Mock<IEntityRepository<Product>>();
        productRepositoryMock.Setup(m => m.GetByID(productId)).Returns(product).Verifiable();
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(m => m.productRepository).Returns(productRepositoryMock.Object);
        IProductService sut = new ProductService(unitOfWorkMock.Object);
        //Act
        var actual = sut.GetProductName(productId);
        //Assert
        productRepositoryMock.Verify();//verify that GetByID was called based on setup.
        Assert.IsNotNull(actual);//assert that a result was returned
        Assert.AreEqual(expected, actual);//assert that actual result was as expected
    }
