    [Test]
    public async void GetSomethingTest()
    {
        var service = SimpleIoc.Default.GetInstance<IService>();
        var result = service.TryGetSomethingAsync(20).Result;
        Assert.IsTrue(result.IsSuccess);
        Assert.IsNotNull(result.ReturnValue);
    }
