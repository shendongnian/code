    [Fact]
    public void ControlIsGeneratedCorrectly()
    {
        var expected = new CustomControl { Foo = "Foo", Bar = 16 };
        var parser = new CustomControlParser();
        var model = new SomeViewModel { Foo = "Foo" };
        var actual = parser.Parse(Html.InputFor(model));
        Assert.AreEqual(expected.Foo, actual.Foo);
        Assert.AreEqual(expected.Bar, actual.Bar);
    }
