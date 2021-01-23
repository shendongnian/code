    [Theory]
    [InlineData("I", 1)]
    [InlineData("II", "2")]
    [InlineData("III", "3")]
    public void test(string roman, int number)
    {
        var actual = Program.Convert(roman);
        Assert.AreEqual(actual, number);
    }
