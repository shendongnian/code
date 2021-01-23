    [TestFixture]
    public class StorageStatisticsGeneratorTests
    {
        private Mock<IProductRepository> _productRepository;
        private StorageStatisticsGenerator _statisticGenerator;
        [SetUp]
        public void Setup()
        {
            _productRepository = new Mock<IProductRepository>();
            _statisticGenerator = new StorageStatisticsGenerator(_productRepository.Object);
        }
        // In this test we test if the statistic generator works correctly
        // This is a UNIT TEST
        [Test]
        public void ComputeNumberOfProducts_Should_Returns_TheCorrectCount()
        {
            // Arrange
            _productRepository.Setup(p => p.LoadProducts()).Returns(new List<Product>
            {
                new Product(), new Product(), new Product()
            });
            
            // Act
            int result = _statisticGenerator.ComputeNumberOfProducts();
            // Assert
            Assert.AreEqual(3, result);
        }
        // In this test we test if the statistic generator use the repository as expected
        // This is an INTERACTION TEST, you could check corner case using "real life data"
        [Test]
        public void ComputeNumberOfProducts_Should_Use_The_Product_Repository()
        {
            // Arrange
            _productRepository.Setup(p => p.LoadProducts()).Returns(new List<Product>
            {
                new Product()
            });
            // Act
            _statisticGenerator.ComputeNumberOfProducts();
            // Assert
            _productRepository.Verify(p => p.LoadProducts());
        }
        // In this test we use the real repository this is an INTEGRATION TEST
        // You can flag this kind of slow test to run only during the night for instabce
        [Test, Category("Nightly")]
        public void ComputeNumberOfProducts_Should_Correctly_Integrate_With_ProductRepository()
        {
            // Arrange
            _statisticGenerator = new StorageStatisticsGenerator(new ProductRepository());
            // Act
            _statisticGenerator.ComputeNumberOfProducts();
            // Assert
            _productRepository.Verify(p => p.LoadProducts());
        }
    }
