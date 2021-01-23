    [Theory]
    [InlineData("37.60")]
    public void MyDecimalTest(String number)
    {
        var d = Convert.ToDecimal(number);
        Assert.Equal(d, 37.60M);
    }
