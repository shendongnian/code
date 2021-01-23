    public class FooTests
    {
        private readonly IAppData _mockAppData;
    
        public FooTests()
        {
            var mockAppData = new Mock<IAppData>();
            mockAppData.Setup(m => m.GetAppData(It.IsAny<string>)).Returns("my test value");
            _mockAppData = mockAppData.Object;
        }
    
        [Fact]
        public void IsValidVoucher_ValidAppData_Returns()
        {
            var foo = new Foo(_mockAppData);
            // Unit test foo.IsValidVoucher
        }
    }
