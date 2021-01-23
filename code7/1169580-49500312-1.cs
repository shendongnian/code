    [Fact]
    public void BuildWithThird()
    {
        var fixture = new Fixture();
        var actual =
            fixture.Get((X x, One first, Two second) =>
                x.WithFirst(first.WithSecond(second.WithThird("ploeh"))));
        Assert.Equal("ploeh", actual.First.Second.Third);
        Assert.NotNull(actual.Foo);
        Assert.NotEqual(default(int), actual.First.Bar);
        Assert.NotEqual(default(bool), actual.First.Second.Baz);
    }
