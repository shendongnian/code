    [TestFixture]
    public class HttpClientTests
    {
        private ISystemUnderTest _systemUnderTest;
        private HttpMessageHandler _mockMessageHandler;
        
        [SetUp]
        public void Setup()
        {
            _mockMessageHandler = A.Fake<HttpMessageHandler>();
            var httpClient = new HttpClient(_mockMessageHandler);
            _systemUnderTest = new SystemUnderTest(httpClient);
        }
        [Test]
        public void HttpError()
        {
            // Arrange
            A.CallTo(_mockMessageHandler)
                .Where(x => x.Method.Name == "SendAsync")
                .WithReturnType<Task<HttpResponseMessage>>()
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent("abcd")
                }));
            // Act
            var result = _systemUnderTest.DoSomething();
            // Assert
            // Assert.AreEqual(...);
        }
    }
