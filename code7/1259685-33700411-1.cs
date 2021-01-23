    [Fact]
    public void UseCustomization()
    {
        var fixture = new Fixture().Customize(new Customization());
        var c = fixture.Create<Class>();
        var i = fixture.Create<IInterface>();
        Assert.Equal(c, i);
    }
