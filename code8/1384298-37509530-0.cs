    [Test]
    public void TestedEntity_GivenParemeter_Passes(
        [ValueSource(nameof(FirstSource))] int inputA,
        [ValueSource(nameof(SecondSource))] int inputB)
    {
        if (inputA > 0 && inputB > 0)
            Assert.Pass();
    }
    private static readonly int[] FirstSource = { 1, 2 };
    private static readonly IEnumerable<int> SecondSource = Enumerable.Range(1, 4);
