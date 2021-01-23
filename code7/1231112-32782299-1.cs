    [Theory, AutoData]
    public void GenerateTwoDistinctNonZeroIntegersWithAutoFixtureXunit(
        Generator<int> generator)
    {
        var numbers = generator.Where(x => x != 0).Distinct().Take(2);
        // -> 72, 117
    }
