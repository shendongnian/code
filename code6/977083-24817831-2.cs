    [Test]
    public Task GetSomethingTest()
    {
        var service = SimpleIoc.Default.GetInstance<IService>();
        return service.TryGetSomethingAsync(20).ContinueWith(t =>
        {
            var result = t.Result;
            Assert.IsTrue(result.IsSuccess);
            Assert.IsNotNull(result.ReturnValue);
        });
    }
