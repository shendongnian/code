    [Theory, AutoData]
    public void ShouldBeSum_AutoData(int a, int b, Summer uut)
    {
        uut.Add(a);
        uut.Add(b);
        Assert.Equal(a + b, uut.Value); // Passes
    }
