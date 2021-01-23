        public static Mock<HttpMessageHandler> CreateHttpMessageHandler(List<HttpResponseMessage> responses)
            {
                var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
                handlerMock.Protected()
                    .Setup<Task<HttpResponseMessage>>(
                    nameof(HttpClient.SendAsync),
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(() => {
                        var response = responses[0];
                        responses.RemoveAt(0);
                        return response;
                    })
                    .Verifiable();
    
                return handlerMock;
            }
