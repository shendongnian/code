    [Fact]
    public async Task SomeTest()
    {
        var itemList = ...;
        var tasks = itemList.Select(async item =>
        {
            var i = await Something(item);
            return i;
        }).ToArray();
        await Task.WhenAll(tasks);
        Assert.All(tasks, task => Assert.Equal(1, task.Result));
    }
