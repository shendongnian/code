    [Fact]
    public async Task AmIAliveTest()
    {
       var server = TestServer.Create<Startup>();
       var httpClient = server.HttpClient;
       var response = await httpClient.GetAsync("/api/status");
       response.StatusCode.Should().Be(HttpStatusCode.OK);
       var resultString = await response.Content.ReadAsAsync<string>();
       resultString.Should().Be("I am alive!");
    }
