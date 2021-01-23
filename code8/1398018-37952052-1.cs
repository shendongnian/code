    public class MiddlewareIntegrationTests : IClassFixture<TestFixture<SystemUnderTest.Startup>>  
    {
        public MiddlewareIntegrationTests(TestFixture<SystemUnderTest.Startup> fixture)
        {
            Client = fixture.Client;
        }
    
        public HttpClient Client { get; }
    
        [Fact]
        public async Task AllMethods_RemovesServerHeader(string method)
        {
           // Arrange
           var request = new HttpRequestMessage(new HttpMethod("GET"), "/");
           // Act
           var response = await Client.SendAsync(request);
           //assert etc
        }
    }
