    [Theory]
    [InlineData("Allowed", "Allowed")]
    [InlineData("foo", "foo")]
    [InlineData("bar", "bar")]
    public void Testing(string test1Data, string test2Data)
    {
        Assert.Equal(test1Data, test2Data);
    }
