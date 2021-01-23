    [Fact]
    public void Divide_TwoNumbers_ExpectException()
    {
        var sut = new Calculator();
        var exception = Record.Exception(() => sut.Divide(10, 0));
        Assert.IsType(typeof(DivideByZeroException), exception);
    }
