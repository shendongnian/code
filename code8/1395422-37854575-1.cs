    [Theory]
    [InlineData("37.60")]
    public void MyDecimalTest(Decimal number)
    {
        Assert.Equal(number, 37.60M);
    }
