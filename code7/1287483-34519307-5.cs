    [TestFixture]
    public class ExampleTestFixture
    {
        private ITestRepository CreateRepositoryStub(fake data)
        {
            var testRepositoryStub = ...; // create the stub with a mocking framework
            // make the stub return given fake data
            return testRepositoryStub;
        }
        [Test]
        public void GivenX_WhenDropDownListIsRequested_ReturnsY()
        {
            // Arrange
            var testRepositoryStub = CreateRepositoryStub(X);
            var testController = new TestController(testRepositoryStub);
            // Act
            var result = testController.DropDownList();
            // Assert
            Assert.That(result, Is.Equal(Y));
        }  
    }
