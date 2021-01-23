    [Fact]
    public void LocationExists_True()
    {
        Assert.True(_repository.LocationExists(_dbFixture.GoodLocationId));
    }
