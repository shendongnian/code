    [Fact]
    public void Workaround()
    {
        var fixture = new Fixture().Customize(new AutoMoqCustomization());
        var response = fixture.Freeze<Mock<HttpResponseBase>>();
        response.SetupProperty(x => x.StatusCode);
        response.Object.StatusCode = 42;
        Assert.Equal(42, response.Object.StatusCode);
    }
