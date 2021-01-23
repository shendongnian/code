    [Fact]
    public void Should_throw_argument_exception_when_the_input_strings_are_invalid()
    {
        var assertion = new ValidatesTheStringArguments(new Fixture());
        var sut = typeof(SystemUnderTest).GetMethod("SomeMethod");
    
        assertion.Verify(sut);
    }
