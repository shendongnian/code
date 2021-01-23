    [Fact, Trait("Category", "Product")]
    public async Task Create_Service_With_Null_Financial_ContactPerson_Should_Fail() {
        // Arrange
        var entity = ObjectFactory.Service.CreateService(packageId = 1);
    
        var productServiceRepositoryMock = new Mock<IProductServiceRepository>();
    
        var productPackageRepositoryMock = new Mock<IProductPackageRepository>();
        productPackageRepositoryMock
            .Setup(repository => repository.AnyAsync(It.IsAny<Expression<Func<ProductPackageEntity, bool>>>()))
            .ReturnsAsync(false);
        //Make use of the Lazy<T>(Func<T>()) constructor to return the mock instances
        var lazyProductPackageRepository = new Lazy<IProductPackageRepository>(() => productPackageRepositoryMock.Object);
        var lazyProductServiceRepository = new Lazy<IProductServiceRepository>(() => productServiceRepositoryMock.Object);
        var sut = new ProductServiceService(lazyProductServiceRepository, lazyProductPackageRepository);
    
        // Act
        var result = await sut.AddServiceAsync(service);
    
        // Assert
        Assert.False(result.Succeeded);
        Assert.Contains(result.ErrorMessages, error => error.Contains(string.Format(NameMessageResource.NotFoundError, NameMessageResource.ProductPackage)));
    }
