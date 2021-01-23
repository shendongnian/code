    [Theory]
    [InlineData("604475587", true)]
    [InlineData("00 258 9460", true)]
    [InlineData("604475587asdfsf", false)]
    [InlineData("444", false)]
    [InlineData(null, false)]
    public void IsValidAcn(string acn, bool expectedValidity)
    {
        var sut = GetSystemUnderTest();
        Assert.True(sut.IsValidAcn(acn) == expectedValidity);
    }
