    [Fact]
    public void TestMethod1()
    {
        object testInt = 1;
        object testString = "123";
        double testDouble = 1.0;
        string testWrong = "abc";
        int resultInt = testInt.Convert<int>();
        string resultString = testString.Convert<string>();
        int resultIntString = testString.Convert<int>();
        int dbl2int = testDouble.Convert<int>();
        Assert.Throws<Exception>(() => testWrong.Convert<int>());
        Assert.Equal(1, resultInt);
        Assert.Equal("123", resultString);
        Assert.Equal(123, resultIntString);
        Assert.Equal(1, dbl2int);
    }
