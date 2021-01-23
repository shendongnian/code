    [Fact]
    public void UseTypeRelay()
    {
        var fixture = new Fixture();
        fixture.Customizations.Add(
            new TypeRelay(
                typeof(IInterface),
                typeof(Class)));
        fixture.Freeze<Class>();
        var c = fixture.Create<Class>();
        var i = fixture.Create<IInterface>();
        Assert.Equal(c, i);
    }
