    [TestClass]
    public class MyServiceTests
    {
        [TestMethod]
        public void GetTest()
        {
            var mock = new Mock<MyService>();
            var service = mock.Object;
            service.Get();
            mock.Verify(s => s.SuperImportantMethod(), Times.Once);
        }
    }
