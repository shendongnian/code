    [Fact]
    public void CreatePointDoesNotThrow()
    {
        var fixture = new Fixture().Customize(new PointCustomization());
        var e = Record.Exception(() => fixture.Create<Point>());
        Assert.Null(e);
    }
