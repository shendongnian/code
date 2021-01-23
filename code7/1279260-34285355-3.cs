    [Theory]
    [InlineAutoData(null)]
    [InlineAutoData("")]
    [InlineAutoData(" ")]
    public void Should_throw_argument_exception_when_input_string_is_invalid(
        string input1,
        string input2,
        string input3)
    {
        Assert.Throws<ArgumentException>(() =>
            SystemUnderTest.SomeFunction(input1, input2, input3));
    }
 
