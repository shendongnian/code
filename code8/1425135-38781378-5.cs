    [Theory]
    [InlineData("33 102 417 032", true)]
    [InlineData("29002589460", true)]
    [InlineData("33 102 417 032asdfsf", false)]
    [InlineData("444", false)]
    [InlineData(null, false)]
    public void IsValidAbn(string abn, bool expectedValidity)
    {
        var sut = GetSystemUnderTest();
        Assert.True(sut.IsValidAbn(abn) == expectedValidity);
    }
