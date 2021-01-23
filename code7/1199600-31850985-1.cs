    [Theory()]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("     ")]
    public void Constructor_InvalidName_ExceptionThrown(string name)
    {
        Assert.Throws<ArgumentNullException>(() => new Foo(name));
    }
