    [TestClass]
    public class MockLazyOfTWithMoqTest {
        [TestMethod]
        public async Task Method_Under_Test_Should_Return_True() {
            // Arrange
            var productServiceRepositoryMock = new Mock<IProductServiceRepository>();
            var productPackageRepositoryMock = new Mock<IProductPackageRepository>();
            productPackageRepositoryMock
                .Setup(repository => repository.AnyAsync())
                .ReturnsAsync(false);
            //Make use of the Lazy<T>(Func<T>()) constructor to return the mock instances
            var lazyProductPackageRepository = new Lazy<IProductPackageRepository>(() => productPackageRepositoryMock.Object);
            var lazyProductServiceRepository = new Lazy<IProductServiceRepository>(() => productServiceRepositoryMock.Object);
            var sut = new ProductServiceService(lazyProductServiceRepository, lazyProductPackageRepository);
            // Act
            var result = await sut.MethodUnderTest();
            // Assert
            Assert.IsTrue(result);
        }
        public interface IProductServiceService { }
        public interface IProductServiceRepository { }
        public interface IProductPackageRepository { Task<bool> AnyAsync();}
        public class ProductServiceService : IProductServiceService {
            private readonly Lazy<IProductServiceRepository> _repository;
            private readonly Lazy<IProductPackageRepository> _productPackageRepository;
            public ProductServiceService(
                Lazy<IProductServiceRepository> repository,
                Lazy<IProductPackageRepository> productPackageRepository) {
                _repository = repository;
                _productPackageRepository = productPackageRepository;
            }
            public async Task<bool> MethodUnderTest() {
                var errors = new List<ValidationResult>();
                if (!await _productPackageRepository.Value.AnyAsync())
                    errors.Add(new ValidationResult("error"));
                return errors.Any();
            }
        }
    }
