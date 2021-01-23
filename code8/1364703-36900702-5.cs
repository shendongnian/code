    [Fact]
    public async Task ShouldFoo()
    {
        const string baseAddress = "http://localhost:8000";
        using (WebApp.Start<Startup>(baseAddress))
        {
            var httpclient = new HttpClient
            { 
                BaseAddress = new Uri(baseAddress)
            };
            var response = await httpclient.GetAsync("/");
            Assert.That(...);
        }
    }
