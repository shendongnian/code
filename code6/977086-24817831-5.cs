    [Test]
    public async Task GetSomethingTest()
    {
        var service = SimpleIoc.Default.GetInstance<IService>();
        var result = await service.TryGetSomethingAsync(20);
        Assert.IsTrue(result.IsSuccess);
        Assert.IsNotNull(result.ReturnValue);
    }
