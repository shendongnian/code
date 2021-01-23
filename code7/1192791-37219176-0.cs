    public class TestHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.OK), cancellationToken);
        }
    }
     // in your test class method
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://foo.com");
        var handler = new FooHandler()
        {
            InnerHandler = new TestHandler()  // <-- change to use this
        };
        var invoker = new HttpMessageInvoker(handler);
        var result = await invoker.SendAsync(httpRequestMessage, new CancellationToken());
        Assert.That(result.Headers.GetValues("some-header").First(), Is.Not.Empty, "");
