    public static class PostAsyncTests
    {
        public class Given_A_Uri_And_A_JsonMessage_When_Posting_Async
            : Given_WhenAsync_Then_Test
        {
            private SalesOrderHttpClient _sut;
            private Uri _uri;
            private string _content;
            private string _expectedResult;
            private string _result;
    
            protected override void Given()
            {
                _uri = new Uri("http://test.com/api/resources");
                _content = "{\"foo\": \"bar\"}";
                _expectedResult = "{\"result\": \"ok\"}";
    
                var httpClientFactoryMock = new Mock<IHttpClientFactory>();
                var messageHandlerMock =
                    new MockHttpMessageHandler((request, cancellation) =>
                    {
                        var responseMessage =
                            new HttpResponseMessage(HttpStatusCode.Created)
                            {
                                Content = new StringContent("{\"result\": \"ok\"}")
                            };
    
                        var result = Task.FromResult(responseMessage);
                        return result;
                    });
    
                var httpClient = new HttpClient(messageHandlerMock);
                httpClientFactoryMock
                    .Setup(x => x.Create())
                    .Returns(httpClient);
    
                var httpClientFactory = httpClientFactoryMock.Object;
    
                _sut = new SalesOrderHttpClient(httpClientFactory);
            }
    
            protected override async Task WhenAsync()
            {
                _result = await _sut.PostAsync(_uri, _content);
            }
    
    
            [Fact]
            public void Then_It_Should_Return_A_Valid_JsonMessage()
            {
                _result.Should().BeEquivalentTo(_expectedResult);
            }
        }
    }
