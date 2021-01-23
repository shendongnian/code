    [Fact]
    public async Task SomeTest()
    {
        var itemList = ...;
        var results = await Task.WhenAll(itemList.Select(async item =>
        {
            var i = await Something(item);
            return i;
        }));
        Assert.All(results, result => Assert.Equal(1, result));
    }
