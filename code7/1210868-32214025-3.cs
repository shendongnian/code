    [TestFixture]
    public class Class1
	{
		private Mock<IUnitOfWork> _unitOfWorkMock;
		private Mock<IRepository<Dummy>> _dummyRepositoryMock;
		private Mock<IRepository<ProductType>> _productTypeRepositoryMock;
		[SetUp]
		public void Setup()
		{
			_unitOfWorkMock = new Mock<IUnitOfWork>();
			_dummyRepositoryMock = CreateMock<Dummy>();
			_productTypeRepositoryMock = CreateMock<ProductType>();
			_unitOfWorkMock.Setup(u => u.Dummies).Returns(_dummyRepositoryMock.Object);
			_unitOfWorkMock.Setup(u => u.ProductTypes).Returns(_productTypeRepositoryMock.Object);
		}
		[Test]
		public void product_type_service_should_add_item_to_the_underlying_repository()
		{
			var productTypeService = new ProductTypeService(_unitOfWorkMock.Object);
			var productType = new ProductType {Id = 10};
			productTypeService.AddProductType(productType);
			_productTypeRepositoryMock.Verify(r => r.Add(It.Is<ProductType>(p => p.Id == productType.Id)), Times.Once());
		}
		
	    private Mock<IRepository<T>> CreateMock<T>() where T : class
	    {
		    var mock = new Mock<IRepository<T>>();
			// do more common magic here
		    return mock;
	    }
    }
