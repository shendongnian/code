    [TestFixture]
    public class ExampleTestFixture
    {
        private IExampleRepository CreateRepositoryStub(fake data)
        {
            var exampleRepositoryStub = ...; // create the stub with a mocking framework
            // make the stub return given fake data
            return exampleRepositoryStub;
        }
        [Test]
        public void GivenX_WhenDropDownListIsRequested_ReturnsY()
        {
            // Arrange
            var exampleRepositoryStub = CreateRepositoryStub(X);
            var exampleController = new ExampleController(exampleRepositoryStub);
            // Act
            var result = exampleController.DropDownList();
            // Assert
            Assert.That(result, Is.Equal(Y));
        }  
    }
