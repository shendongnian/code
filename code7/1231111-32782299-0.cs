    [Fact]
    public void GenerateTwoDistinctNonZeroIntegersWithAutoFixture()
    {
        var fixture = new Fixture();
        var generator = fixture.Create<Generator<int>>();
        var numbers = generator.Where(x => x != 0).Distinct().Take(2);
        // -> 72, 117
    }
