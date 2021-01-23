    [Fact]
    public void ReducedRepro()
    {
        var response = new Mock<HttpResponseBase>();
        response.CallBase = true;
        Assert.Throws<NotImplementedException>(() =>
            response.SetupSet(x => x.StatusCode = It.IsAny<int>()));
    }
