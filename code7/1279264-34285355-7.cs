    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Should_throw_argument_exception_when_input_string_is_invalid(string input)
    {
        Assert.Throws<ArgumentException>(() => SystemUnderTest.SomeFunction(input));
    }
