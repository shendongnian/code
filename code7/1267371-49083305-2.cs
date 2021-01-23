    [Fact]
    public void FillBarsZeroOutAllOtherSequences()
    {
        var fixture = new Fixture();
        var actual = fixture.Create<Foo>();
        new TypeElement(actual.GetType()).Accept(new EmtpyEnumerables(actual));
        actual.Bars = fixture.CreateMany<Bar>();
        Assert.NotEmpty(actual.Bars);
        Assert.Empty(actual.Bazs);
        Assert.Empty(actual.Quxs);
        Assert.NotEqual(default(string), actual.Corge);
        Assert.NotEqual(default(int), actual.Grault);
    }
