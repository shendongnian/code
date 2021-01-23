    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public async Task MyTestMethod()
        {
            var httpClient = new HttpClient(new MockHttpMessageHandler());
            var content = await httpClient.GetStringAsync("http://some.fake.url");
    
            Assert.AreEqual("Content as string", content);
        }
    }
    
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Content as string")
            };
    
            return await Task.FromResult(responseMessage);
        }
    }
