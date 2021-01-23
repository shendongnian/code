    [TestCase(null, typeof(ArgumentNullException))]
    [TestCase("this is invalid", typeof(ArgumentException))]
    public void SomeMethod_With_Invalid_Argument(string arg, Type expectedException)
    {
        Assert.Throws(expectedException, () => SomeMethod(arg));
    }
