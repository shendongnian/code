    [Fact]
    public void BuildWithLenses()
    {
        var fixture = new Fixture();
            
        var actual = fixture.Get((X x) =>
            X.FirstLens.Compose(One.SecondLens).Compose(Two.ThirdLens).Set(x, "ploeh"));
        Assert.Equal("ploeh", actual.First.Second.Third);
        Assert.NotNull(actual.Foo);
        Assert.NotEqual(default(int), actual.First.Bar);
        Assert.NotEqual(default(bool), actual.First.Second.Baz);
    }
