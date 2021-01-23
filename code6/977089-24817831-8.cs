    [Test]
    public void GetSomethingTest()
    {
        var service = SimpleIoc.Default.GetInstance<IService>();
        service.TryGetSomethingAsync(20).ContinueWith(t =>
        {
            var result = t.Result;
            Assert.IsTrue(result.IsSuccess);
            Assert.IsNotNull(result.ReturnValue);
        });
    }
