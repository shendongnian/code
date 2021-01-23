    [Theory]
    [InlineData(new[] { 4, 3, 2, 1 }, 6)]
    [InlineData(new[] { 1, 3, 5, 2, 4, 6 }, 3)]
    [InlineData(new[] { 5, 6, 2, 3, 1, 4, 7 }, 10)]
    public void ParameterizedCountInversionTest(int[] input, int expected)
    {
        Sorter sut = new Sorter();
        var actual = sut.CountInversion(input);
        Assert.Equal(expected, actual);
    }
